using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middleware {
    public static class ActorsLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseActorsRequestLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ActorsLogMiddleware>();
        }
    }
}
