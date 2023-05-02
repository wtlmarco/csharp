using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class EnderecoTextual : IFormatadorEndereco
{
    private int contadorDeUso = 0;

    private static EnderecoTextual instanciaCompartilhada;

    public async Task Formatar(HttpContext context, IEndereco endereco)
    {
        StringBuilder conteudo = new StringBuilder();
        conteudo.Append($"CEP: {endereco.CEP}\n");
        conteudo.Append($"Logradouro: {endereco.Logradouro}\n");
        conteudo.Append($"Complemento: {endereco.Complemento}\n");
        conteudo.Append($"Bairro: {endereco.Bairro}\n");
        conteudo.Append($"Cidade/UF: {endereco.Localidade}/{endereco.Estado}\n");
        conteudo.Append($"\nFormatador usado: {++contadorDeUso} vez(es).\n");
        
        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync(conteudo.ToString());
    }

    //Desing Pattern Singleton que gera somente uma instância de objeto
    //a ser compartilhado por todos os utilizadores da classe
    //dessa maneira o contadorDeUso é sempre atualizado pois é chamado
    //da mesma instância do objeto
    public static EnderecoTextual Singleton
    {
        get
        {
            if(instanciaCompartilhada == null)
            {
                instanciaCompartilhada = new EnderecoTextual();
            }

            return instanciaCompartilhada;
        }
    }
}