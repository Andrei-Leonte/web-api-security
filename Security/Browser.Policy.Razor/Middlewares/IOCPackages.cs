namespace Browser.Policy.Razor.Middlewares
{
    public static class IOCPackages
    {
        public static void RegisterPackages(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<CSPMiddleware>();
        }
    }
}
