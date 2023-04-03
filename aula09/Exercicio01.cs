/*
Curso Básico de C#
Aula 09 - Estudo de Caso da Classe Pessoa

Exercício 01
*/
using System;

namespace Aula09;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Estudo de Caso da Classe Pessoa");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Pessoa p1 = new Pessoa("Albert", "Einstein", new DateTime(1955,6,17), "98765432101");
        p1.Peso = 76;
        p1.Altura = 1.78;
        p1.MostrarDados();
        p1.Comer(2.5);
        p1.Comer(3800);
        p1.Correr(7,30);
        p1.MostrarDados();

        Console.WriteLine();

        Pessoa p2 = new Pessoa("Ada", "Lovelace", new DateTime(1975,4,18), "A5432134567", 62, 1.65);
        p2.MostrarDados();
    }
}