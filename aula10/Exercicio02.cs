/*
Curso Básico de C#
Aula 10 - Herança de Classes

Exercício 02 - Acessando atributo protected ou atributos herdados
*/
using System;

namespace Aula10;

public class Exercicio02
{
    private static void WriteHeader(){
        Console.WriteLine("Herança de Classes");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Aviao a1 = new Aviao(3200, 4, 16, 12, 12);
        Console.WriteLine($"O peso é {a1.Peso}");
        //Console.WriteLine($"O peso é {a1.Densidade}");
    }
}