using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder;

//Classe utilizada para Injeção de Dependência usando o serviço já configurado no Program.cs 
public static class MetodosExtensao
{
    public static void MapConsultaCep(this IEndpointRouteBuilder app, string path)
    {
        IFormatadorEndereco formatador = app.ServiceProvider.GetService<IFormatadorEndereco>();

        app.MapGet(path, context => EndpointConsultaCep.Endpoint(context, formatador));
    }

    //Método genérico para mapear rotas Endpoint e serviços que consomem Injeção de Dependência
    public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string caminho, string nomeMetodo = "Endpoint")
    {
        MethodInfo mi = typeof(T).GetMethod(nomeMetodo);
        if(mi == null || mi.ReturnType != typeof(Task))
        {
            throw new System.Exception("Método não é compatível");
        }

        T instanciaEndpoint = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

        app.MapGet(caminho, (RequestDelegate)mi.CreateDelegate(typeof(RequestDelegate), instanciaEndpoint));
    }
}