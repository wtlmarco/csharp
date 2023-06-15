using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using CloudWeather.Temperature.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TemperatureDbContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient
);

var app = builder.Build();

app.MapGet("/observation/{zip}", async (string zip, [FromQuery] int? days, TemperatureDbContext db) => {
    if (days == null || days < 1 || days > 30)
    {
        return Results.BadRequest("Please provide a 'days' query parameter between 1 and 30");
    }

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);

    var result = await db.Temperature
        .Where(t => t.ZipCode == zip && t.CreatedOn > startDate)
        .ToListAsync();

    return Results.Ok(result);
});

app.MapPost("/observation", async (Temperature temperature, TemperatureDbContext db) =>
{
    temperature.CreatedOn = temperature.CreatedOn.ToUniversalTime();
    await db.AddAsync(temperature);
    await db.SaveChangesAsync();
});

app.Run();
