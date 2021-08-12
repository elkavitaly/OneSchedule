using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.IO;
using Telegram.Bot;
using Microsoft.Extensions.Options;
using OneSchedule.Settings;

namespace OneSchedule
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionHandlingMiddleware> logger, IOptions<TelegramSettings> options)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BotAppInternalException ex)
            {
                logger.LogError($"Bot applictionn internal exception: {ex}");
                await HandleExceptionAsync(httpContext, ex, options);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex, options);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IOptions<TelegramSettings> options)
        {
            var message = $"Internal Server Error from the custom middleware. {exception.Message}";
            string jsonString = string.Empty;

            using (StreamReader stream = new StreamReader(context.Request.Body))
            {
                jsonString = await stream.ReadToEndAsync();
            }

            Update update = JsonSerializer.Deserialize<Update>(jsonString);

            var chatId = update.Message.Chat.Id;

            var bot = new TelegramBotClient(options.Value.ApiKey);

            await bot.SendTextMessageAsync(chatId, message);
        }
    }
}
