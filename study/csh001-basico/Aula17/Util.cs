using System;

namespace Aula17
{
    public static class Util
    {
        static double valorDolar = 5.78;
        public static double ValorDolar
        {
            get { return valorDolar; }
            set { valorDolar = value; }
        }

        public static double ObterValorComDesconto(double valor, double percentualDesconto)
        {
            double desconto = valor * (percentualDesconto / 100);
            double resultado = valor - desconto;

            return resultado;
        }

        public static double ObterValorEmDolares(double valorEmReais)
        {
            return valorEmReais / Util.ValorDolar;
        }

        public static List<Pessoa> ObterListaPessoas(int quantidadePessoas)
        {
            var lista = new List<Pessoa>();
            Random rnd = new Random();

            for (int i = 0; i < quantidadePessoas; i++)
            {
                lista.Add(new Pessoa($"Pessoa{i:D3}", rnd.Next(1, 6)));
            }

            //lista[(int)(quantidadePessoas / 3)] = null;

            return lista;
        }
    }
}
