using System.Text;

namespace aula04.Duplo;

public class EtapaDuploPintura : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        string[] cores = {"PRETO", "BRANCO", "PRATA", "VERMELHO", "GRAFITE"};

        var random = new Random();
        var corAleatoria = cores[random.Next(0, cores.Length)];
        entrada.Insert(0, $"[{corAleatoria}]", 1);
        entrada.Insert(entrada.Length, $"[{corAleatoria}]", 1);
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;

        return entrada;
    }
}