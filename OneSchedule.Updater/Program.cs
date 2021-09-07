using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

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
                    }

                    try
                    {
                        var response = await RedirectUpdatesToApi(updates, client, programSettings);
                        Console.WriteLine($"\n{response}\n_________");
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

        private static async Task<HttpResponseMessage> RedirectUpdatesToApi(IEnumerable<Update> updates, HttpClient client, ProgramSettings programSettings)
        {
            foreach (var update in updates)
            {
                var jsonUpdate = JsonConvert.SerializeObject(update);
                var content = new StringContent(jsonUpdate, Encoding.UTF8, "application/json");
                return await client.PostAsync(programSettings.Uri, content);
            }

            return null;
        }
    }
}
