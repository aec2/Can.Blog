using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Can.Blog
{
    public class ErrorHandlingMiddleware
    {
        readonly RequestDelegate _next;
        static ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            string error = "An internal server error has occured.";
            error = $"{exception.Source} - {exception.Message} - {exception.StackTrace} - {exception.TargetSite.Name}";
            _logger.LogError(error);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
