using Browser.Policy.Razor.Middlewares;

namespace Browser.Policy.Razor.Startups
{
    public static class MiddlewareStartup
    {
        public static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<CSPMiddleware>();
        }
    }
}
