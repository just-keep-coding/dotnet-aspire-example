using Carter;
using Core.Application;
using Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

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

app.Run();
