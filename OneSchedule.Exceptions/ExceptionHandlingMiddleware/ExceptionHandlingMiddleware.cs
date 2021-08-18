using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
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
            var message = $"Internal Server Error from the custom middleware. {exception.Message}";
            string jsonString;

            using (var stream = new StreamReader(context.Request.Body))
            {
                jsonString = await stream.ReadToEndAsync();
            }

            SendExceptionToChat(jsonString, message);
        }

        private async void SendExceptionToChat(string jsonString, string message)
        {
            var updates = JsonConvert.DeserializeObject<List<Update>>(jsonString,
                new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

            if (updates != null)
            {
                var chatId = updates.FindLast(u => true)?.Message.Chat.Id;

                await _bot.SendTextMessageAsync(chatId, message);
            }
        }
    }
}
