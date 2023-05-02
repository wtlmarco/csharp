using System.Text;

namespace aula04.Duplo;

public class EtapaDuploPortas : IEtapaDuplo<StringBuilder>
{
    public IEtapaDuplo<StringBuilder> ProximaEtapa { get; set; }
    public StringBuilder Processar(StringBuilder entrada)
    {
        entrada.Insert(0, "[PORTAS]", 2);
        entrada.Insert(entrada.Length, "[PORTAS]", 2);
        entrada = ProximaEtapa?.Processar(entrada) ?? entrada;

        int postPortaEsquerda = entrada.ToString().IndexOf("[PORTA]");
        entrada.Insert(postPortaEsquerda, "[MAÇANETA]",2);
        int postPortaDireita = entrada.ToString().IndexOf("[PORTA]");
        entrada.Insert(postPortaDireita, "[MAÇANETA]",2); 
        return entrada;
    }
}