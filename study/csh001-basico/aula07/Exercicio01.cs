/*
Curso Básico de C#
Aula 07 - Construtor Estático e Destrutor

Exercício 01
*/
using System;

namespace Aula07;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Construtor Estático e Destrutor");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }

    static void CriarObjetos(){
         Carro c1 = new Carro();
        c1.Modelo = "Fusca";
        c1.Portas = 4;
        c1.Preco = 29990;

        Carro c2 = new Carro();
        c2.Modelo = "Opala";
        c2.Portas = 4;
        c2.Preco = 49990;

        Carro c3 = new Carro("Chevete");
        c3.Portas = 4;
        c3.Preco = 32990;

        Carro c4 = new Carro("Monza",4,39990);

        Carro c5 = new Carro(1190);

    }
    
    public static void Run(){
        WriteHeader();

        CriarObjetos();
        
        Console.WriteLine("Objetos já não são mais utilizados.");

        GC.Collect();
    }
}