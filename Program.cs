using FastEndpoints;
using OsonAptekaFastEndpoints.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAppService(builder.Configuration);
builder.Services.AddFastEndpoints();
var app = builder.Build();
app.UseFastEndpoints();
app.Run();
