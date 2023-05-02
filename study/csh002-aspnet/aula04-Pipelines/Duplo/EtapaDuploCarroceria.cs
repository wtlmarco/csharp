using System.Text;

namespace aula04.Duplo;

public class EtapaDuploCarroceria : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Insert(0, "[CARROCERIA]", 1);
        entrada.Insert(entrada.Length, "[CARROCERIA]", 1);
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;

        return entrada;
    }
}