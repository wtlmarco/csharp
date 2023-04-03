/*
Curso Básico de C#
Aula 10 - Herança de Classes

Exercício 01 - Conceito base de Herança
*/
using System;

namespace Aula10;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Herança de Classes");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Aviao a1 = new Aviao(3200, 4, 16, 12, 12);
        a1.Voar(1000);
    }
}