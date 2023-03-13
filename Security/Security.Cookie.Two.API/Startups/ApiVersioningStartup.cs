using Microsoft.AspNetCore.Mvc.Versioning;

namespace Security.Cookie.Two.API.Startups
{
    public static class ApiVersioningStartup
    {
        public static void SetApiVersioning(this WebApplicationBuilder builder)
        {
            builder.Services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
            });
        }
    }
}
