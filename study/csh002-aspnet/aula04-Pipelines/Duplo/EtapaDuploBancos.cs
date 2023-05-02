using System.Text;

namespace aula04.Duplo;

public class EtapaDuploBancos : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Insert(0, "[BANCOS]", 2);
        entrada.Insert(entrada.Length, "[BANCOS]", 2);
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;

        return entrada;
    }
}