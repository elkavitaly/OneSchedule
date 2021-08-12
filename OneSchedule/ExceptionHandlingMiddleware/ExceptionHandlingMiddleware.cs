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

namespace OneSchedule
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BotAppInternalException ex)
            {
                logger.LogError($"Bot applictionn internal exception: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var message = $"Internal Server Error from the custom middleware. {exception.Message}";
            string jsonString = string.Empty;

            using (StreamReader stream = new StreamReader(context.Request.Body))
            {
                jsonString = await stream.ReadToEndAsync();
            }

            Update update = JsonSerializer.Deserialize<Update>(jsonString);

            var chatId = update.Message.Chat.Id;

            var bot = new TelegramBotClient("1774119603:AAFCWMV12zS0SLBx4kC3A-suLJ511wP4oOo");

            await bot.SendTextMessageAsync(chatId, message);
        }
    }
}
