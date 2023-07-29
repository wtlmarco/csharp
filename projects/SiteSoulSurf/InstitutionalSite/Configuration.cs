using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NLog;
using NLog.Web;

namespace SoulSurf.InstitutionalSite;

internal static class Configuration
{
    public static Logger Logger { get { return LogManager.GetCurrentClassLogger(); } }

    public static void ConfigureBuilder(this WebApplicationBuilder builder)
    {
        // Add NLog for Logging
        LogManager.Setup().LoadConfigurationFromAppSettings();
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddRazorPages();
    }

    public static void Configure(this IApplicationBuilder app, IHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        ((WebApplication) app).MapRazorPages();
    }
}
