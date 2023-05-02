using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

public class MiddlewareTempoExecucao
{
    private readonly RequestDelegate _next;

    public MiddlewareTempoExecucao(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke (HttpContext context)
    {
        context.Response.ContentType = "text/plain; charset=utf-8";
        var sw = Stopwatch.StartNew();
        await _next(context);
        sw.Stop();

        var tempo = sw.ElapsedMilliseconds;
        await context.Response.WriteAsync($"\nTempo de Execução (ms): {tempo}");
    }
}