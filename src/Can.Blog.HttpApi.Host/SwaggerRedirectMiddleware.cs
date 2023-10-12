using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Can.Blog
{
    public class SwaggerRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/swagger")
            {
                httpContext.Response.Redirect("/swagger/index.html");
                return;
            }

            await _next(httpContext);
        }
    }

    public static class SwaggerRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseSwaggerRedirect(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerRedirectMiddleware>();
        }
    }

}
