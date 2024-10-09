using OsonAptekaFastEndpoints.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppService(builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
