using System.Text;
using System.Text.Json;


HttpClient _ = new();
/// есть еще другой вариант кода,даже забавнее но для него нужна были бы доп. либа. исполняемый код решения задачи в таком случае приходил бы извне
Console.WriteLine("Задача 3: Позабыты хлопоты, остановлен бег,\r\nВкалывают роботы," +
        " а не человек.\n");
Console.WriteLine("Условия задачи");
_.DefaultRequestHeaders.Clear();
_.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/143.0.0.0 Safari/537.36 Edg/143.0.0.0");
_.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "https://decopy.ai  ");
_.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "https://decopy.ai/  ");
_.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "ru,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
_.DefaultRequestHeaders.TryAddWithoutValidation("product-code", "067003");
_.DefaultRequestHeaders.TryAddWithoutValidation("product-serial", "4832f92cb84b53ee98ad91418ca37f48");
string zadacha = "CHTO-TO POSHLO NE TYAK";
string input = "Составь простую алгоритмическую задачу в стиле leetCode." +
" Обрати внимание что задача должна быть решаема тобой, в ней должно быть " +
"несколько наборов данных. В ОТВЕТЕ ОТПРАВЬ ИСКЛЮЧИТЕЛЬНО ЗАДАЧУ. Не пиши формат функции," +
"а также не используй форматирование текста, никаких жирных слов или курсивов";
try
{
    zadacha = await ChatWithAiAsync(input);

}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"[FATAL ERROR] {ex.Message}");
    Console.ResetColor();
}
Console.WriteLine(zadacha);
bool ended = false;

Console.WriteLine("Введите набор данных для задачи. Что бы закончить набор, введите !!??");
var sb = new StringBuilder();
while (ended is false)
{
    var str = Console.ReadLine();
    if (str == "!!??") ended = true;
    sb.Append(str);
    sb.Append("\n");
}
try
{
    string reshenie = await ChatWithAiAsync("Привет. Есть задача: " + zadacha +
        " Есть к ней набор данных: " + sb.ToString() + "Тебе надо решить " +
        "эту задачу на этом наборе данных. В ответе пришли толко выходные " +
        "данные задачи, и ничего больше! Совсем больше ничего! ТОЛЬКО ОТВЕТЫ ЗАДАЧИ К НАБОРУ ДАННЫХ!!");
    Console.WriteLine(reshenie);

}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"[FATAL ERROR] {ex.Message}");
    Console.ResetColor();
}

async Task<string> ChatWithAiAsync(string prompt)
{
    var chatId = Guid.NewGuid().ToString();
    var chatGroup = DateTime.UtcNow.ToString("yyyy-MM-dd");

    using var formData = new MultipartFormDataContent("----WebKitFormBoundaryCAfDOOYqE2SKD00V");
    formData.Add(new StringContent(prompt), "entertext");
    formData.Add(new StringContent(chatId), "chat_id");
    formData.Add(new StringContent("DeepSeek-V3"), "model");
    formData.Add(new StringContent(chatGroup), "chat_group");

    var createJobUrl = "https://api.decopy.ai/api/decopy/ask-ai/create-job  ";
    var createResponse = await _.PostAsync(createJobUrl, formData);
    var createJson = await createResponse.Content.ReadAsStringAsync();
    using var createDoc = JsonDocument.Parse(createJson);
    if (!createDoc.RootElement.TryGetProperty("result", out var resultElement) ||
        !resultElement.TryGetProperty("job_id", out var jobIdElement))
    {
        Console.WriteLine("Перезапустите прогамму или проверьте подключение к сети");
        throw new Exception();
    }

    string jobId = jobIdElement.GetString();
    var sseUrl = $"https://api.decopy.ai/api/decopy/ask-ai/get-job/{jobId}";

    var sseRequest = new HttpRequestMessage(HttpMethod.Get, sseUrl);
    sseRequest.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
    sseRequest.Headers.TryAddWithoutValidation("Cache-Control", "no-cache");

    using var sseResponse = await _.SendAsync(sseRequest, HttpCompletionOption.ResponseHeadersRead);

    await using var stream = await sseResponse.Content.ReadAsStreamAsync();
    using var reader = new StreamReader(stream, Encoding.UTF8);

    var fullAnswer = new StringBuilder();

    while (!reader.EndOfStream)
    {
        var line = await reader.ReadLineAsync();
        if (string.IsNullOrEmpty(line)) continue;

        if (line.StartsWith("data: "))
        {
            var jsonPart = line.Substring(6);
            if (jsonPart.Trim() == "Data transfer completed.")
            {
                break;
            }
            try
            {
                using var doc = JsonDocument.Parse(jsonPart);
                if (doc.RootElement.TryGetProperty("data", out var dataElement))
                {
                    string chunk = dataElement.GetString();
                    fullAnswer.Append(chunk);
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\nОшибка JSON в SSE: {ex.Message} | Строка: {line}");
            }
        }
    }
    return fullAnswer.ToString();
}

