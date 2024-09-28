using Notificator.Api.AppServices;
using Notificator.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddAzureWebAppDiagnostics();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddEmailServices();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddNotificationEndpoints();

app.Run();
