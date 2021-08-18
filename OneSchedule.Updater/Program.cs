using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Text.Json.Serialization;

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

            await bot.SetWebhookAsync(string.Empty);

            while (true)
            {
                await Task.Delay(1000);

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
                        Console.WriteLine($"send:  {update.Message.Text}");
                    }

                    try
                    {
                        await RedirectUpdatesToApi(updates, client, programSettings);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static Task<HttpResponseMessage> RedirectUpdatesToApi(IEnumerable updates, HttpClient client, ProgramSettings programSettings)
        {
            var jsonUpdates = JsonSerializer.Serialize(updates);
            var content = new StringContent(jsonUpdates, Encoding.UTF8, "application/json");
            var response = client.PostAsync(programSettings.Uri, content);
            return response;
        }
    }
}
