using System.Text;

namespace aula04.Simples;

public class EtapaChassi : IEtapa<StringBuilder>
{
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Append("[CHASSI]");

        return entrada;
    }
}