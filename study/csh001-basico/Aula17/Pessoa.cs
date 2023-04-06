using System.Runtime.CompilerServices;

namespace Aula17
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public double Desconto { get; set; }

        public Pessoa(string nome, double desconto)
        {
            this.Nome = nome;
            this.Desconto = desconto;
        }
    }
}
