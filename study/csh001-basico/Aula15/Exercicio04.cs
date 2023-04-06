/*
Curso Básico de C#
Aula 15 - Eventos e Delegates

Exercício 04 - Multicast de chamadas a variáveis delegate
*/
using System;

namespace Aula15;

public class Exercicio04
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

        OperacaoMatematicaBinaria opMulticast = Somar;
        opMulticast += Multiplicar;
        opMulticast += Potenciar;
        opMulticast += delegate (double a, double b)
        {
            double r = a / b;
            Console.WriteLine($"A divisão de {a} por {b} é igual a {r}.");
            return r;
        };

        opMulticast(2, 3);
    }
}