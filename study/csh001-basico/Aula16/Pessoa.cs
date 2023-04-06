using System;

namespace Aula16
{
    class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, string sobrenome, int idade)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
        }
    }
}
