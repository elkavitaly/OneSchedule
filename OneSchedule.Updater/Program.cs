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
                .Build();

            var apiKey = configuration["ApiKey"];
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
                        var response = await client.PostAsync(@"https://localhost:44339/api​/update",
                            new StringContent(JsonConvert.SerializeObject(updates)));
                        var content=await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                Thread.Sleep(111);
            }
        }
    }
}
