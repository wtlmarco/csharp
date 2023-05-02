namespace App.Extensions;

public static class StringExtensions
{
    public static string PrimeiraPalavra(this string texto)
    {
        var pos = texto.IndexOf(" ");
        if(pos > 0)
            return texto.Trim().Substring(0, texto.IndexOf(" "));
        else
            return texto;
    }
}