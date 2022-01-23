using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelFinder.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _loggger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory logggerFactory)
        {
            _next = next;
            _loggger = logggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _loggger.LogInformation(
                        "Request {method} {url} => {statusCode}",
                        context.Request.Method,
                        context.Request.Path.Value,
                        context.Response.StatusCode
                     );
            }
        }
    }
}
