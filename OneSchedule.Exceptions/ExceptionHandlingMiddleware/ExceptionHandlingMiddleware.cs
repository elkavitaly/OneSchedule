﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace OneSchedule.Exceptions.ExceptionHandlingMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly ITelegramBotClient _bot;
        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger, ITelegramBotClient bot)
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
            var message = $"Internal Server Error from the custom middleware. {exception.Message}. Inner: {exception.InnerException?.Message}";
            string jsonString;

            using (var stream = new StreamReader(context.Request.Body))
            {
                jsonString = await stream.ReadToEndAsync();
            }

            SendExceptionToChat(jsonString, message);
        }

        private async void SendExceptionToChat(string jsonString, string message)
        {
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                var updates = JsonSerializer.Deserialize<Update[]>(jsonString);

                if (updates != null && updates.Any())
                {
                    var update = updates.First();
                    var chatId = update.Message.Chat.Id;

                    await _bot.SendTextMessageAsync(chatId, message);
                }
            }
        }
    }
}
