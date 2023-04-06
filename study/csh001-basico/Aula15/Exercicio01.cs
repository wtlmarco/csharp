/*
Curso Básico de C#
Aula 15 - Eventos e Delegates

Exercício 01 - Variável do tipo delegate que armazena funções
*/
using System;

namespace Aula15;

public class Exercicio01
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
    public static double Potencia(double x, double y)
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

        OperacaoMatematicaBinaria op = new OperacaoMatematicaBinaria(Multiplicar);
        op(10, 20);
    }
}