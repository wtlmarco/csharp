using System.Text;
using ServidorHttpSimples;

class PaginaTiposmime : PaginaDinamica
{
    public override byte[] Get(SortedList<string,string> parametros)
    {
        StringBuilder htmlGerado = new StringBuilder();
        try
        {
            htmlGerado.Append($"<li>{Program.Servidor}</li>");
            
            foreach (var p in Program.Servidor.TiposMime.Keys)
            {
                htmlGerado.Append($"<li>Arquivos com extensão {p}</li>");
            }
        }
        catch(Exception e)
        {
            htmlGerado.Append($"<li>{e.Message}</li>");
        }

        string textoHtmlGerado = this.HtmlModelo.Replace("{{HtmlGerado}}", htmlGerado.ToString());

        return Encoding.UTF8.GetBytes(textoHtmlGerado);
    }   
}