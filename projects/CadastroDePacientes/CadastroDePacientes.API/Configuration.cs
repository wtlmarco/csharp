using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using FluentValidation;

using CadastroDePacientes.API.Data;
using CadastroDePacientes.API.Log;
using CadastroDePacientes.API.Models.Validators;
using CadastroDePacientes.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using CadastroDePacientes.API.Extensions;

namespace CadastroDePacientes.API;

internal static class Configuration
{
    public static void RegisterAppServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();

        services.AddDbContext<IApplicationDbContext, SqlServerDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default")));

        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        services.AddSingleton<ILoggerManager, LoggerManager>();

        services.AddScoped<IValidator<Paciente>, PacienteValidator>();
        services.AddScoped<IValidator<Convenio>, ConvenioValidator>();
    }

    public static void ConfigureAppPipeline(this WebApplication app)
    {
        app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerManager>());

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseAuthorization();

        app.MapControllers();
    }
}
