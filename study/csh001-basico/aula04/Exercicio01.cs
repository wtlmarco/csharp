/*
Curso Básico de C#
Aula 04 - Métodos Construtores e Métodos Comuns

Exercício 01
*/
using System;

namespace Aula04;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Métodos Construtores e Métodos Comuns");
        Console.WriteLine("---------------");
    }
    
    public static void Run(){
        WriteHeader();
        
        Produto p1 = new Produto();
        p1.Nome = "Banana";
        p1.Preco = 3.9;
                
        Console.WriteLine($"{p1.Nome} = R${p1.Preco:F2}");
        
        p1.Comprar(20);
        p1.Vender(3);
        Console.WriteLine(p1.ObterTexto());

        Produto p2 = new Produto("Laranja", 4.75);
        p2.Comprar(100);
        p2.Vender(17);
        Console.WriteLine(p2.ObterTexto());

        Produto p3 = new Produto("Abacaxi", 3.25);
        p3.Comprar(50);
        p3.Vender(21);
        Console.WriteLine(p3.ObterTexto());
        
        //p3.Estoque = 200;
        Console.WriteLine("Estoque: " + p3.Estoque);
        
    }
}