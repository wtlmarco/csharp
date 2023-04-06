/*
Curso Básico de C#
Aula 15 - Eventos e Delegates

Exercício 05 - Interceptando chamadas com delegate e eventos
*/
using System;

namespace Aula15;

public class Exercicio05
{
    public delegate void OcorrenciaDeOperacao(double resultado);

    public delegate double OperacaoMatematicaBinaria(double x, double y);

    public static event OcorrenciaDeOperacao AoOcorrerOperacao;
    public static double Somar(double x, double y)
    {
        double r = x + y;
        AoOcorrerOperacao.Invoke(r);
        return r;
    }
    public static double Multiplicar(double x, double y)
    {
        double r = x * y;
        AoOcorrerOperacao.Invoke(r);
        return r;
    }
    public static double Potenciar(double x, double y)
    {
        double r = Math.Pow(x,y);
        AoOcorrerOperacao.Invoke(r);
        return r;
    }
    private static void WriteHeader(){
        Console.WriteLine("Eventos e Delegates");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        AoOcorrerOperacao += MostrarResultadoNaTela;
        AoOcorrerOperacao += EnviarResultadoPorEmail;
        AoOcorrerOperacao += GravarResultadoEmArquivo;

        OperacaoMatematicaBinaria opMulticast = Somar;
        opMulticast += Multiplicar;
        opMulticast += Potenciar;
        opMulticast += delegate (double a, double b)
        {
            double r = a / b;
            AoOcorrerOperacao.Invoke(r);
            return r;
        };

        opMulticast(2, 3);
    }

    public static void MostrarResultadoNaTela(double r)
    {
        Console.WriteLine($"Resultado: {r}");
    }

    public static void EnviarResultadoPorEmail(double r)
    {
        Console.WriteLine($"Enviando e-mail com resultado {r}...");
    }

    public static void GravarResultadoEmArquivo(double r)
    {
        Console.WriteLine($"Gravando arquivo com resultado {r}...");
    }
}