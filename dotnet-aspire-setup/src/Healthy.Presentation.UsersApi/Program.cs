using Carter;
using Healthy.Core.Application;
using Healthy.Infrastructure.Database;
using Healthy.Presentation.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCarter();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddDatabaseInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();
app.MapOpenApi();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
app.MapCarter();
app.MapDefaultEndpoints();

app.Run();
