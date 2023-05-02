using System.Text;

namespace aula04.Simples;

public class EtapaBancos : IEtapa<StringBuilder>
{
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Insert(0, "[BANCOS]", 2);
        entrada.Insert(entrada.Length, "[BANCOS]", 2);

        return entrada;
    }
}