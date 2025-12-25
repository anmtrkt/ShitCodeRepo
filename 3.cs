public static class Program
{
    public static void Main(string[] args)
    {
        long t = long.Parse(Console.ReadLine());
        long Seconds;
        long CommandsCount;
        long startPoint;

        List<Робот> роботы = new();

        for (int i = 0; i < t; i++)
        {
            string vvod = Console.ReadLine();
            var vvod2 = vvod.Split(" ");
            CommandsCount = long.Parse(vvod2[0]);
            startPoint = long.Parse(vvod2[1]);
            Seconds = long.Parse(vvod2[2]);
            string commands = Console.ReadLine();
            Робот rob = new() {Seconds = Seconds };
            int c = 0;
            foreach (var @char in commands.ToCharArray())
            {
                rob.Команды ??= new KeyValuePair<int, Команда>[commands.ToCharArray().Length];
                rob.Команды[c] = new(c, new() { Команда1 = @char.ToString() });
                c++;
            }
            rob.тт = new() { Точка1 = startPoint };
            роботы.Add(rob);

        }
        for (int i = 0; i < роботы.Count; i++)
        {
            роботы[i].Выполнитькоманды();
        }
    }
    public struct Команда
    {
        public string Команда1;
    }
    public class Робот
    {

        public KeyValuePair<int, Команда>[] Команды;
        public Точка тт;
        public long Seconds;
        public long счК;
        public long счН;

        public void Выполнить_команду(int команда)
        {
            if (команда is 1) СистемаКоординат.ПереместитьВ_Право(1);
            if (команда is 2) СистемаКоординат.ПереместитьВ_Лево(1);
        }
        public void Выполнитькоманды()
        {
            СистемаКоординат.Очистить();
            СистемаКоординат.ТТ = тт;
            while (Seconds > 0)
            {
                if ((счК > Команды.Length - 1) && (тт.Точка1 != 0))
                {
                    break;
                }
                Seconds--;

                var command = Команды.FirstOrDefault(x => x.Key == счК);
                switch (command.Value.Команда1.ToCharArray()[0])
                {
                    case 'L':
                        Выполнить_команду(2);
                        break;
                    case 'R':
                        Выполнить_команду(1);
                        break;
                }
                счК++;
                тт = СистемаКоординат.ТТ;
                if (тт.Точка1 == 0)
                {
                    счК = 0;
                    счН++;
                }
             
            }
            Console.WriteLine(счН);
        }
    }
    public struct Точка
    {
        public long Точка1;
    }
    static class СистемаКоординат
    {

        static public void Очистить()
        {
            Точки = null;
            lastPointPoint = 0;
        }

        static public Точка ТТ;
        static int lastPointPoint;

        static public KeyValuePair<int, Точка>[] Точки;
        static public void ПереместитьВ_Право(int сколько)
        {
            if (сколько > 1 || сколько < 1) throw new Exception();

            if ( Точки is null || Точки.Length is 0)
            {
                Точка точка1 = new() { Точка1 = ТТ.Точка1 };
                Точки = new KeyValuePair<int, Точка>[1];
                Точки[0] = new(1, точка1);
            }
            var temp = Точки[lastPointPoint].Value.Точка1;
            var итог = temp + сколько;

            KeyValuePair<int, Точка> точка = Точки.Where(x => x.Value.Точка1 == итог).FirstOrDefault(defaultValue: new(-100500, new()));

            if (точка.Key is -100500 )
            {
                Точка точка1 = new() { Точка1 = итог };
                KeyValuePair<int, Точка>[] точкиКоп = (KeyValuePair<int, Точка>[])Точки.Clone();
                Точки = new KeyValuePair<int, Точка>[точкиКоп.Length + 1];
                for (int i = 0; i < точкиКоп.Length; i++)
                {
                    Точки[i] = точкиКоп[i];
                }
                Точки[точкиКоп.Length] = new(точкиКоп.Length + 1, точка1);
                ТТ = Точки.Last().Value;
                lastPointPoint = точкиКоп.Length;
                return;
            }
            else
            {
                ТТ = точка.Value;
                lastPointPoint = точка.Key - 1;

            }
             
        }
        static public void ПереместитьВ_Лево(int сколько)
        {
            if (сколько > 1 || сколько < 1) throw new Exception();

            if ( Точки is null || Точки.Length is 0)
            {
                Точка точка1 = new() { Точка1 = ТТ.Точка1 };
                Точки = new KeyValuePair<int, Точка>[1];
                Точки[0] = new(1, точка1);
            }
            var temp = Точки[lastPointPoint].Value.Точка1;
            var итог = temp - сколько;

            KeyValuePair<int, Точка> точка = Точки.Where(x => x.Value.Точка1 == итог).FirstOrDefault(defaultValue: new(-100500, new()));

            if (точка.Key is -100500)
            {
                Точка точка1 = new() { Точка1 = итог };
                KeyValuePair<int, Точка>[] точкиКоп = (KeyValuePair<int, Точка>[])Точки.Clone();
                Точки = new KeyValuePair<int, Точка>[точкиКоп.Length + 1];
                for (int i = 0; i < точкиКоп.Length; i++)
                {
                    Точки[i] = точкиКоп[i];
                }
                Точки[точкиКоп.Length] = new(точкиКоп.Length + 1, точка1);
                ТТ = Точки.Last().Value;
                lastPointPoint = точкиКоп.Length;
                return;
            }
            else
            {
                ТТ = точка.Value;
                lastPointPoint = точка.Key - 1;
            }
        }

    }

}

