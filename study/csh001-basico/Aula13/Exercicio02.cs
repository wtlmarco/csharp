/*
Curso Básico de C#
Aula 13 - Interfaces de Classes

Exercício 02
*/
using System;

namespace Aula13;

public class Exercicio02
{
    private static void WriteHeader(){
        Console.WriteLine("Interfaces de Classes");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Random random = new Random();

        List<IAnimal> animais = new List<IAnimal>();
        for (int i = 0; i < 100; i++)
        {
            int sorteio = random.Next();
            if(sorteio % 2 == 0)
            {
                animais.Add(new Cachorro());
            }
            else
            {
                animais.Add(new Macaco());
            }
        }

        foreach (var animal in animais)
        {
            Console.WriteLine("-------------------------------");
            if(animal is IQuadrupede)
            {
                Console.WriteLine("Este animal é um quadrupede");
            }

            if(animal is IBipede)
            {
                Console.WriteLine("Este animal é um bipede");
            }

            if (animal is Cachorro c)
            {
                Console.WriteLine("Este animal é um cachorro");
                c.Farejar();
            }

            if(animal is Macaco m)
            {
                Console.WriteLine("Este animal é um macaco");
                m.Caminhar();
            }
        }
    }
}