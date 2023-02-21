using MicroserviceDemo;
using Shed.CoreKit.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorrelationToken();
builder.Services.AddControllers();
builder.Services.AddTransient<HttpClient>();
builder.Services.AddWebApiEndpoints(new WebApiEndpoint<IElementCollection>(new System.Uri("http://localhost:5001")),
    new WebApiEndpoint<IElementsSelected>(new System.Uri("http://localhost:5002")));
builder.Logging.AddConsole();

var app = builder.Build();

app.UseDefaultFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseWebApiRedirect("api/elements", new WebApiEndpoint<IElementCollection>(new System.Uri("http://localhost:5001")));
app.UseWebApiRedirect("api/selectedElements", new WebApiEndpoint<IElementsSelected>(new System.Uri("http://localhost:5002")));

app.Run();
