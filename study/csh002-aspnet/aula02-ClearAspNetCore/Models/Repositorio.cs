using aula02_EnqueteWeb.Models;

public static class Repositorio
{
    private static List<Resposta> respostas = new List<Resposta>();

    public static IEnumerable<Resposta> Respostas {get { return respostas; } }

    public static void AdicionarResposta(Resposta resposta)
    {
        respostas.Add(resposta);
    }

    static Repositorio()
    {
        respostas.Add(new Resposta(){ Nome = "Fulano", Email = "fulano@gmail.com", Sim = true});
        respostas.Add(new Resposta(){ Nome = "Cicrano", Email = "cicrano@gmail.com", Sim = true});
        respostas.Add(new Resposta(){ Nome = "Beltrano", Email = "beltrano@gmail.com", Sim = true});
    }
}