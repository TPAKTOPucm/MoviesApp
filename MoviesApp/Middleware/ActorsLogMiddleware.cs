using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MoviesApp.Middleware {
    public class ActorsLogMiddleware {
        private readonly RequestDelegate _next;
        public ActorsLogMiddleware(RequestDelegate next) {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ILogger logger) { 
            if (context.Request.Path == "/Actors") {
                logger.LogTrace($"Request: {context.Request.Path}  Method: {context.Request.Method}");
            }
            await _next(context);
        }
    }
}
