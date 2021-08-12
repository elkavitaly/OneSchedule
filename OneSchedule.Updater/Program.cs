using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
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

            var apiKey = configuration["ApiKey"];
            var uri = configuration.GetSection("RequstUri").Value;
            var bot = new TelegramBotClient(apiKey);
            var offset = 0;

            var client = new HttpClient();

            await bot.SetWebhookAsync("");

            while (true)
            {
                var updates = await bot.GetUpdatesAsync(offset);
                
                if (updates.Any())
                {
                    try
                    {
                        foreach (var update in updates) 
                        {
                            offset = update.Id + 1;
                        }

                        var serializedUpdates = JsonConvert.SerializeObject(updates);
                        var response = await client.PostAsync(uri, new StringContent(serializedUpdates));
                        Console.WriteLine($"sent {updates.Length} updates");
                        var content=await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }
    }
}
