using System.Text;

namespace aula04.Duplo;

public class EtapaDuploMotor : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Append("[MOTOR]");
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;
        
        return entrada;
    }
}