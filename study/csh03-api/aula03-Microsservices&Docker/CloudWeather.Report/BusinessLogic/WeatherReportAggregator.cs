using Microsoft.Extensions.Options;

using CloudWeather.Report.DataAccess;

namespace CloudWeather.Report.BusinessLogic;

public interface IWeatherReportAggregator
{
    /// <summary>
    /// Builds and returns a Weather Report.
    /// Persists WeeklyWeatherReport date
    /// </summary>
    /// <param name="zip"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public Task<WeatherReport> BuildWeeklyReport(string zip, int days);
}
public class WeatherReportAggregator
{
    private readonly IHttpClientFactory _http;
    private readonly ILogger<WeatherReportAggregator> _logger;
    private readonly WeatherDataConfig _weatherDataConfig;
    private readonly WeatherReportDbContext _db;

    public WeatherReportAggregator(IHttpClientFactory http, 
        ILogger<WeatherReportAggregator> logger,
        IOptions<WeatherDataConfig> weatherConfig,
        WeatherReportDbContext db)
    {
        _http = http;
        _logger = logger;
        _weatherDataConfig = weatherConfig.Value;
    }
}
