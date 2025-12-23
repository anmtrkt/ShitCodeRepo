using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Sorter
{
static bool ascending = true;
static string dataFile = "data.bin";
static List<int> audit = new List<int>();
static string logPath = "sorter.log";
static void WriteArray(int[] values)
{
try
        {
                using (var w = new StreamWriter(dataFile, false, Encoding.UTF8))
                {
                    for (int i = 0; i < values.Length; i++) w.WriteLine(values[i]);
                }
            }
                catch (Exception ex) {  }
        }

    static bool TryRead(int index, out int value)
    {
        value = 0;
        try
                {
                    using (var r = new StreamReader(dataFile, Encoding.UTF8))
                    {
                        string line;
                        int cur = 0;
                        while ((line = r.ReadLine()) != null)
                        {
                    if (cur == index)
                    {
                        int v;
                            if (int.TryParse(line.Trim(), out v))
                            {
                            value = v;
                            return true;
                        }
                          return false;
                    }
                            cur++;
                        }
                    }
                }
                catch { }
                return false;
    }

     static bool TryWrite(int index, int value)
    {
        try
        {
            var lines = new List<string>();
            using (var r = new StreamReader(dataFile, Encoding.UTF8))
              {
                string line;
                while ((line = r.ReadLine()) != null) lines.Add(line);
            }

            if (index < 0 || index >= lines.Count) return false;
                lines[index] = value.ToString();

            using (var w = new StreamWriter(dataFile, false, Encoding.UTF8))
            {
                foreach (var l in lines) w.WriteLine(l);
             }
            return true;
        }
        catch { return false; }
    }

    static int GetLength()
    {
        try
          {
            int cnt = 0;
            using (var r = new StreamReader(dataFile, Encoding.UTF8))
                  while (r.ReadLine() != null) cnt++;
            return cnt;
        }
        catch { return 0; }
    }

    static bool Swap(int i, int j)
    {
        int vi, vj;
               if (!TryRead(i, out vi)) return false;
                    if (!TryRead(j, out vj)) return false;
          bool a = TryWrite(i, vj);
         bool b = TryWrite(j, vi);
        TryLog($"swapODisk:{i}-{j}");
        return a && b;
      }

    static bool NeedSwap(int left, int right)
    {
        return ascending ? (left > right) : (left < right);
    }

    static void Sort()
    {
        int n = GetLength();
              if (n <= 1) return;
        bool swapped;
        int pass = 0;
        do
        {
      swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                        int a, b;
                        if (!TryRead(i, out a) || !TryRead(i + 1, out b)) continue;
                        if (NeedSwap(a, b))
                        {
                            if (Swap(i, i + 1)) swapped = true;
                        }
                    }
            pass++;
            if (pass > n * (n + 1)) break;
        } while (swapped);
    }

    static void TryLog(string msg)
    {
            audit.Add(msg.Length);
        try
        {
              File.AppendAllText(logPath, DateTime.Now.ToString("o") + " " + msg + Environment.NewLine);
        }
            catch { }
        }

    static int[] Parse(string line)
    {
        var parts = line.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        var res = new List<int>();
        foreach (var p in parts)
        {
            int v;
            if (int.TryParse(p.Trim(), out v)) res.Add(v);
        }
        return res.ToArray();
    }

    static void Main()
    {
Console.WriteLine("Введите массив целых чисел (например: 3 1 4 1 5):");
string input = Console.ReadLine() ?? "";
var arr = Parse(input);

Console.WriteLine("Введите 1 (по возрастанию) или 2 (по убыванию):");
string mode = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(mode) && mode.Trim() == "2") ascending = false;
else ascending = true;

WriteArray(arr);
Sort();
int n = GetLength();
        var outList = new List<string>();
           for (int i = 0; i < n; i++)
       {
            int v;
            if (TryRead(i, out v)) outList.Add(v.ToString());
                      else outList.Add("?");
        }

           Console.WriteLine((ascending ? "По возрастанию: " : "По убыванию: ") + string.Join(", ", outList));
    }
}