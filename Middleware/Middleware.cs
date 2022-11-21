using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WEB_053505_Pronin.Middleware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class Middleware
	{
		private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public Middleware(RequestDelegate next, ILoggerFactory logFactory)
		{
			_next = next;
			_logger = logFactory.CreateLogger<Middleware>();
		}

		public async Task Invoke(HttpContext httpContext)
		{
            await _next(httpContext);

            if (httpContext.Response.StatusCode != StatusCodes.Status200OK)
            {
                var path = httpContext.Request.Path + httpContext.Request.QueryString;
                _logger.LogInformation($"Request {path} returns code {httpContext.Response.StatusCode}");
            }
        }
	}

	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<Middleware>();
		}
	}
}
