using System;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

public static class EndpointConsultaCep
{
    public static async Task Endpoint(HttpContext context, IFormatadorEndereco formatador)
    {
        string cep = context.Request.RouteValues["cep"] as string ?? "01001000";

        var objetoCep = await ConsultaCep(cep);
        if(objetoCep == null)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else
        {
            //Chamada utilizando Design Pattern Broker
            //await  TypeBroker.FormatadorEndereco.Formatar(context, objetoCep);

            //Chamada utilizando o módulo de Injeção de Dependência do Framework
            await  formatador.Formatar(context, objetoCep);
        }
    }

    public static async Task<JsonCep> ConsultaCep(string cep)
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