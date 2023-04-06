/*
Curso Básico de C#
Aula 15 - Eventos e Delegates

Exercício 03 - Função anônima
*/
using System;

namespace Aula15;

public class Exercicio03
{
    public delegate double OperacaoMatematicaBinaria(double x, double y);
    public static double Somar(double x, double y)
    {
        double r = x + y;
        Console.WriteLine($"A soma de {x} e {y} é igual a {r}.");
        return r;
    }
    public static double Multiplicar(double x, double y)
    {
        double r = x * y;
        Console.WriteLine($"A multiplicação de {x} e {y} é igual a {r}.");
        return r;
    }
    public static double Potenciar(double x, double y)
    {
        double r = Math.Pow(x,y);
        Console.WriteLine($"A potência de {x} e {y} é igual a {r}.");
        return r;
    }
    private static void WriteHeader(){
        Console.WriteLine("Eventos e Delegates");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        List<OperacaoMatematicaBinaria> operacoes = new List<OperacaoMatematicaBinaria>();
        operacoes.Add(delegate (double x, double y)
        {
            double r = x / y;
            Console.WriteLine($"A divisão de {x} e {y} é igual a {r}.");
            return r;
        });

        foreach (var item in operacoes)
        {
            item(10, 2);
            item(20, 3);
            item(30, 4);
            Console.WriteLine();
        }
    }
}