using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;

namespace OneSchedule.Updater
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .AddJsonFile("appsettings.json")
                .Build();

            var programSettings = new ProgramSettings()
            {
                ApiKey = configuration["ApiKey"],
                Uri = configuration.GetSection("RequstUri").Value
            };

            var bot = new TelegramBotClient(programSettings.ApiKey);
            var offset = 0;

            var client = new HttpClient();

            await bot.DeleteWebhookAsync();

            while (true)
            {
                await Task.Delay(100);

                try
                {
                    var updates = await bot.GetUpdatesAsync(offset);

                    if (!updates.Any())
                    {
                        continue;
                    }

                    foreach (var update in updates)
                    {
                        offset = update.Id + 1;
                        Console.WriteLine($"send:  {update.Message?.Text}");
                        try
                        {
                            var jsonUpdate = JsonSerializer.Serialize(update);
                            var content = new StringContent(jsonUpdate, Encoding.UTF8, "application/json");
                            client.PostAsync(programSettings.Uri, content);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
