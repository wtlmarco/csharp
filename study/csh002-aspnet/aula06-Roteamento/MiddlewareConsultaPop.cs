using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Text;

public class MiddlewareConsultaPop
{
    private readonly RequestDelegate next;

    public MiddlewareConsultaPop(RequestDelegate nextMiddleware)
    {
        next = nextMiddleware;
    }

    public MiddlewareConsultaPop()
    {
    }
 
    public async Task Invoke(HttpContext context)
    {
        string localidade = HttpUtility.UrlDecode(context.Request.RouteValues["local"] as string);

        var populacao = (new Random()).Next(999, 999999);
        
        StringBuilder html = new StringBuilder();
        html.Append($"<h3>População de {localidade.ToUpper()}</h3>");
        html.Append($"<p>{populacao:N0} habitantes</p>");

        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync("*** MiddlewareConsultaPop by Invoke***<br>");
        await context.Response.WriteAsync(html.ToString());
        
        if(next != null)
        {
            await next(context);
        }
    }
}