namespace Browser.Policy.Razor.Middlewares
{
    public class CSPMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var csp = "base-uri 'self'; default-src 'self'; img-src data: https:; object-src 'none'; script-src 'self' 'unsafe-eval'; style-src 'self'; upgrade-insecure-requests;";

            if (!context.Response.Headers.ContainsKey("Content-Security-Policy"))
            {
                //context.Response.Headers.Add("Content-Security-Policy", csp);
            }

            await next(context);
        }
    }
}
