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
        private string _apiKey;
        private ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, IOptions<TelegramSettings> options,
                                            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _apiKey = options.Value.ApiKey;
            _logger = logger;
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

            Update update = JsonSerializer.Deserialize<Update>(jsonString);

            var chatId = update.Message.Chat.Id;

            var bot = new TelegramBotClient(_apiKey);

            await bot.SendTextMessageAsync(chatId, message);
        }
    }
}
