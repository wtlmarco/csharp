using System;
using Microsoft.AspNetCore.Builder;

using NLog;

using SoulSurf.InstitutionalSite;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureBuilder();

builder.Services.ConfigureServices();

Configuration.ConfigureServices(builder.Services);

var app = builder.Build();

app.Configure(app.Environment);

try 
{
    Configuration.Logger.Info("Init website configuration...");
    
    app.Run();
}
catch(Exception ex)
{
    Configuration.Logger.Error(ex, "Error in init");
    throw;
}
finally
{
    LogManager.Shutdown();
}

