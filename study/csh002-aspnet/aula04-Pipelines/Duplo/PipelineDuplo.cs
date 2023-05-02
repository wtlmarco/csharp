using System.Collections.Generic;

namespace aula04.Duplo;

public class PipelineDuplo<T>
{
    private List<IEtapaDuplo<T>> etapas = new List<IEtapaDuplo<T>>();

    public PipelineDuplo<T> AdicionarEtapa(IEtapaDuplo<T> etapa)
    {
        etapas.Add(etapa);
        return this;
    }

    public T Processar(T entrada)
    {
        for (int i = 0; i < etapas.Count -  1; i++)
        {
            etapas[i].ProximaEtapa = etapas[i + 1];
        }

        return etapas[0].Processar(entrada);
    }
}