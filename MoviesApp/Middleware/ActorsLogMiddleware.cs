using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MoviesApp.Middleware
{
    public class ActorsLogMiddleware
    {
        private readonly RequestDelegate _next;
        public ActorsLogMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ILogger logger)
        { 
            if (context.Request.Path == "/Actor")
            {
                logger.LogTrace("Path: " + context.Request.Path + " Method: "+context.Request.Method);
                logger.LogDebug("Session ID: " + context.Session.Id + " Query: " + context.Request.Query + " Body: " + context.Request.Body);
            }
            await _next(context);
        }
    }
}
