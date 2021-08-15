using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
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

            var programSettings = new ProgramSettings(configuration["ApiKey"],
                configuration.GetSection("RequstUri").Value);

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

            Environment.Exit(0);
        }

        private static Task<HttpResponseMessage> RedirectUpdatesToApi(IEnumerable updates, HttpClient client, ProgramSettings programSettings)
        {
            var serializedUpdates = JsonConvert.SerializeObject(updates);
            return client.PostAsync(programSettings.Uri,
                new StringContent(serializedUpdates));
        }
    }
}
