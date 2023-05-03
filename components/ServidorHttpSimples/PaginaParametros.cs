using System.Text;

class PaginaParametros : PaginaDinamica
{
    public override byte[] Get(SortedList<string,string> parametros)
    {
        StringBuilder htmlGerado = new StringBuilder();
        if(parametros.Count > 0)
        {
            htmlGerado.Append("<ul>");
            foreach (var p in parametros)
            {
                htmlGerado.Append($"<li>{p.Key}={p.Value}</li>");
            }
            htmlGerado.Append("</ul>");
        }
        else
        {
            htmlGerado.Append("<p>Nenhum parâmetro informado na URL</p>");
        }
        
        string textoHtmlGerado = this.HtmlModelo.Replace("{{HtmlGerado}}", htmlGerado.ToString());

        return Encoding.UTF8.GetBytes(textoHtmlGerado);
    }   
}