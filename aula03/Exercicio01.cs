/*
Curso Básico de C#
Aula 03 - Atributos, Propriedades e Escopos de Visibilidade

Exercício 01 - 
*/
using System;

namespace Aula03;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Classes, Objetos e Escopos de Visibilidade");
        Console.WriteLine("---------------");
    }
    
    public static void Run(){
        WriteHeader();
        
        Produto p1 = new Produto();
        p1.Nome = "Banana";
        p1.Preco = 3.9;

        Console.WriteLine($"{p1.Nome} = R${p1.Preco:F2}");
    }
}