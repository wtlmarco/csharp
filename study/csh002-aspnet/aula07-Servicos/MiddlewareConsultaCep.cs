using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web;

public class MiddlewareConsultaCep
{
    private readonly RequestDelegate next;

    private IFormatadorEndereco formatador;

    public MiddlewareConsultaCep(IFormatadorEndereco formatadorEndereco)
    {
        formatador = formatadorEndereco;
    }

    public MiddlewareConsultaCep(RequestDelegate nextMiddleware, IFormatadorEndereco formatadorEndereco)
    {
        next = nextMiddleware;
        formatador = formatadorEndereco;
    }

    // public async Task Invoke(HttpContext context)
    // {
    //     if(context.Request.Path.StartsWithSegments("/mw/classe"))
    //     {
    //         string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

    //         string cep = segmentos.Length > 2 ? segmentos[2] : "01001000";
    //         var objetoCep = await ConsultaCep(cep);
            
    //         //Chamada utilizando Design Pattern Broker
    //         //await  TypeBroker.FormatadorEndereco.Formatar(context, objetoCep);
            
    //         //Chamada utilizando o módulo de Injeção de Dependência do Framework
    //         await  formatador.Formatar(context, objetoCep);
    //     }
    //     else if(next != null)
    //     {
    //         await next(context);
    //     }
    // }

        public async Task Invoke(HttpContext context, IFormatadorEndereco formatadorEndereco)
    {
        if(context.Request.Path.StartsWithSegments("/mw/classe"))
        {
            string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

            string cep = segmentos.Length > 2 ? segmentos[2] : "01001000";
            var objetoCep = await ConsultaCep(cep);
            
            //Chamada utilizando Design Pattern Broker
            //await  TypeBroker.FormatadorEndereco.Formatar(context, objetoCep);
            
            //Chamada utilizando o módulo de Injeção de Dependência do Framework
            await  formatadorEndereco.Formatar(context, objetoCep);
        }
        else if(next != null)
        {
            await next(context);
        }
    }

    // public async Task Endpoint(HttpContext context)
    // {
    //     string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

    //     string cep = segmentos.Length > 2 ? segmentos[2] : "01001000";
    //     var objetoCep = await ConsultaCep(cep);
        
    //     await  formatador.Formatar(context, objetoCep);
    // }

    public async Task Endpoint(HttpContext context, IFormatadorEndereco formatadorEndereco)
    {
        string[] segmentos = context.Request.Path.ToString().Split("/", System.StringSplitOptions.RemoveEmptyEntries);

        string cep = segmentos.Length > 2 ? segmentos[2] : "01001000";
        var objetoCep = await ConsultaCep(cep);
        
        await  formatadorEndereco.Formatar(context, objetoCep);
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