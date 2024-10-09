using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.Extensions;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppService(builder.Configuration);
builder.Services.AddFastEndpoints();
var app = builder.Build();
app.UseFastEndpoints();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<AppDbContextSeed>();
try
{
    await context.Database.MigrateAsync();
    var ecommerceContextSeed = new AppDbContextSeed(logger);
    await ecommerceContextSeed.SeedDataAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "Migratsiyalashda muamo");
}
app.Run();
