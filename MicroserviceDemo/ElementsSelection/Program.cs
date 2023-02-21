using MicroserviceDemo;
using MicroserviceDemo.ElementsSelection;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorrelationToken();
builder.Services.AddCors();
builder.Services.AddTransient<IElementsSelected, SelectedImpl>();
builder.Services.AddTransient<HttpClient>();
builder.Services.AddWebApiEndpoints(new WebApiEndpoint<IElementCollection>(new System.Uri("http://localhost:5001")));
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
app.UseWebApiEndpoint<IElementsSelected>();
app.Run();
