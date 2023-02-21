using MicroserviceDemo;
using MicroserviceDemo.ElementCollection;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorrelationToken();
builder.Services.AddCors();
builder.Services.AddTransient<IElementCollection, ElementImpl>();
builder.Logging.AddConsole();

var app = builder.Build();
app.UseCorrelationToken();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseWebApiEndpoint<IElementCollection>();
app.Run();

