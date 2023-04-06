/*
Curso Básico de C#
Aula 17 - Debugando Programas no Visual Studio 2019

Exercício 01
*/
using System;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Aula17;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Debugando Programas no Visual Studio 2019");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        var pessoas = Util.ObterListaPessoas(30);

        Console.Write("<:Calculadora de desconto para a venda:>\nValor da venda: ");
        double valorVenda = Convert.ToDouble(Console.ReadLine());
        Console.Write($"Código do cliente (1 a {pessoas.Count}): ");
        int idCliente = Convert.ToInt32(Console.ReadLine());
        Pessoa cliente = pessoas[idCliente];

        double valorFinal = Util.ObterValorComDesconto(valorVenda, cliente.Desconto);
        Console.WriteLine($"Valor final para {cliente.Nome}: {valorFinal:C}");

        Console.WriteLine();

        double valorFinalEmDolares = Util.ObterValorEmDolares(valorFinal);
        Console.WriteLine($"Valor final US$: {valorFinalEmDolares:F2}");

        Console.WriteLine("Pressione qualquer tecla para prosseguir...");
        Console.ReadKey();

        Console.WriteLine("\nListagem de Pessoas\n---------------------------");
        for (int i = 0; i < pessoas.Count; i++)
        {
            Console.WriteLine($"{pessoas[i].Nome} : {pessoas[i].Desconto:F2}");
        }
    }
}