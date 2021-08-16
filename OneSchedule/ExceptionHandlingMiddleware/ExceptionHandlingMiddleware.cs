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
using OneSchedule.Settings;
using Microsoft.Extensions.Options;

namespace OneSchedule
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly ITelegramBotClient _bot;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, ITelegramBotClient bot)
        {
            _next = next;
            _logger = logger;
            _bot = bot;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BotAppInternalException ex)
            {
                _logger.LogError($"Bot application internal exception: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
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

            SendExceptionToChat(jsonString, message);
        }

        private async void SendExceptionToChat(string jsonString, string message)
        {
            Update update = JsonSerializer.Deserialize<Update>(jsonString);

            var chatId = update.Message.Chat.Id;

            await _bot.SendTextMessageAsync(chatId, message);
        }
    }
}
