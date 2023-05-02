using System;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

public class MiddlewareConsultaCep
{
    private readonly RequestDelegate next;

    public MiddlewareConsultaCep(RequestDelegate nextMiddleware)
    {
        next = nextMiddleware;
    }

    public async Task Invoke(HttpContext context)
    {
        string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

        if(segmentos.Length == 2 && segmentos[0] == "cep")
        {
            var cep = segmentos[1];

            var objetoCep = await ConsultaCep(cep);
            if(objetoCep == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                context.Response.ContentType = "text/html; charset=utf-8";

                await context.Response.WriteAsync("*** MiddlewareConsultaCep ***<br>");

                StringBuilder html = new StringBuilder();
                html.Append($"<h3>Dados de CEP {objetoCep.CEP}</h3>");
                html.Append($"<p>Logradouro: {objetoCep.Logradouro}</p>");
                html.Append($"<p>Bairro: {objetoCep.Bairro}</p>");
                html.Append($"<p>Cidado/UF: {objetoCep.Localidade}/{objetoCep.Estado}</p>");
                
                string localidade = HttpUtility.UrlEncode($"{objetoCep.Localidade}-{objetoCep.Estado}");
                
                //Modo 1 que gera um link fixo para outra rota que aumenta o acoplamento
                html.Append($"<p><a href='/pop/{localidade}'>Consultar População modo 1</a></p>");

                //Modo 2 que utiliza uma referência de rota definida por chave que diminui o acoplamento
                //Esse modelo de Injeção de Dependência aumenta o desacoplamento
                LinkGenerator geradorLink = context.RequestServices.GetService<LinkGenerator>();
                string url = geradorLink.GetPathByRouteValues(context,"consultapop", new {local = localidade});
                html.Append($"<p><a href='{url}'>Consultar População modo 2</a></p>");

                await context.Response.WriteAsync(html.ToString());
            }
        }
        else if(next != null)
        {
            await next(context);
        }
    }

    private async Task<JsonCep> ConsultaCep(string cep)
    {
        var url = $"https://viacep.com.br/ws/{cep}/json/";

        var cliente = new HttpClient();
        cliente.DefaultRequestHeaders.Add("User-Agent","Middleware Consulta CEP");
        var response = await cliente.GetAsync(url);

        var dadosCEP = await response.Content.ReadAsStringAsync();
        dadosCEP = dadosCEP.Replace("?(","").Replace(");","").Trim();

        return dadosCEP.Contains("\"erro\":") ? null : JsonConvert.DeserializeObject<JsonCep>(dadosCEP);
    }
}