using Microsoft.AspNetCore.Builder;

namespace OneSchedule.Exceptions.ExceptionHandlingMiddleware
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}