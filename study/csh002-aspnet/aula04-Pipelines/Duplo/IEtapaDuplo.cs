using aula04.Simples;

namespace aula04.Duplo;
public interface IEtapaDuplo<T> : IEtapa<T>
{
    IEtapaDuplo<T> ProximaEtapa { get; set; }
}