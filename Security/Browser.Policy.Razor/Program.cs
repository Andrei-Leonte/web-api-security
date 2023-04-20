using Browser.Policy.Razor.Middlewares;
using Browser.Policy.Razor.Startups;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.RegisterPackages();

// Rate limiter
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 10;
        options.Window = TimeSpan.FromSeconds(30);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit =1;
    }));

builder.Services.AddControllers();

//Compression
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseHsts();
app.UseStaticFiles();

app.UseRouting();

// Rate limiter
app.UseRateLimiter();

// Compression
app.UseResponseCompression();

app.UseAuthorization();

app.MapRazorPages();
app.ConfigureMiddlewares();

app.MapControllers();
app.Run();
