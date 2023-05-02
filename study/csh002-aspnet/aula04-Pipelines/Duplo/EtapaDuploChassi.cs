using System.Text;

namespace aula04.Duplo;

public class EtapaDuploChassi : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Append("[CHASSI]");
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;

        return entrada;
    }
}