/*
Curso Básico de C#
Aula 13 - Interfaces de Classes

Exercício 01 
*/
using System;

namespace Aula13;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Interfaces de Classes");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Console.WriteLine("Cachorro OSWALDO");
        IAnimal oswaldo = new Cachorro();
        oswaldo.EmitirSom();
        if(oswaldo is Cachorro c)
        {
            c.Farejar();
        }

        Console.WriteLine("---");
        Console.WriteLine();
        Console.WriteLine("Cachorro BILU");

        Cachorro bilu = new Cachorro();
        bilu.EmitirSom();
        bilu.Farejar();

        Console.WriteLine("---");
        Console.WriteLine();
        Console.WriteLine("Cachorro BOLINHA");

        IAnimal bolinha = new Cachorro();
        if(bolinha is IQuadrupede q)
        {
            q.Andar();
        }

        if(bolinha is Cachorro ca)
        {
            ca.Farejar();
        }
    }
}