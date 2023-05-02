using System.Text;

namespace aula04.Simples;

public class EtapaPortas : IEtapa<StringBuilder>
{
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Insert(0, "[PORTAS]", 2);
        entrada.Insert(entrada.Length, "[PORTAS]", 2);

        return entrada;
    }
}