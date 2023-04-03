/*
Curso Básico de C#
Aula 05 - Estudo de Caso de Cadastro de Produtos

Exercício 01
*/
using System;
using System.Collections.Generic;

namespace Aula05;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Estudo de Caso de Cadastro de Produtos");
        Console.WriteLine("---------------");
    }
    
    public static void Run(){
        WriteHeader();

        Produto p1 = new Produto("Maça", 6.2);
        Produto p2 = new Produto("Banana", 2.5);
        Produto p3 = new Produto("Laranja", 3.9);
        Produto p4 = new Produto("Pêra", 5.75);
        Produto p5 = new Produto("Abacaxi", 3.33);
        //Produto p6 = new Produto("A",5);

        List<Produto> produtos = new List<Produto>();
        produtos.Add(p1);
        produtos.Add(p2);
        produtos.Add(p3);
        produtos.Add(p4);
        produtos.Add(p5);

        foreach(Produto p in produtos){
            p.Comprar(100);
            Console.WriteLine(p.ObterTexto());
        }
    }
}