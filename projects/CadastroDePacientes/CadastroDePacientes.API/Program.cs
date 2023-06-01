using Microsoft.AspNetCore.Builder;

using CadastroDePacientes.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterAppServices(builder.Configuration);

var app = builder.Build();

app.ConfigureAppPipeline();

app.Run();
