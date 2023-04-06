/*
Curso Básico de C#
Aula 16 - Programação Assíncrona com Threads e Tasks

Exercício 01 - Threads
*/
using System;
using System.Diagnostics;

namespace Aula16;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Programação Assíncrona com Threads e Tasks");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Stopwatch sw = new Stopwatch();
        sw.Start();
        //ExecutarSequencial();
        ExecutarComThreads();
        sw.Stop();

        Console.WriteLine($"Operação gastou {sw.ElapsedMilliseconds} milissegundos.");
    }

    static void RealizarOperacao(int op, string nome, string sobrenome)
    {
        Console.WriteLine($"Iniciando operação {op}...");
        for (int i = 0; i < 1000000000; i++)
        {
            var p = new Pessoa(nome, sobrenome, 35);
        }

        Console.WriteLine($"Finalizando operação {op}...");
    }

    private static void ExecutarSequencial()
    {
        RealizarOperacao(1, "Fulano", "da Silva");
        RealizarOperacao(2, "Beltrano", "da Silva");
        RealizarOperacao(3, "Sicrano", "da Silva");
    }

    static void ExecutarComThreads()
    {
        var t1 = new Thread(() => 
        {
            RealizarOperacao(1, "Fulano", "da Silva");
        });

        var t2 = new Thread(() =>
        {
            RealizarOperacao(2, "Beltrano", "da Silva");
        });

        var t3 = new Thread(() =>
        {
            RealizarOperacao(3, "Sicrano", "da Silva");
        });

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}