/*
Curso Básico de C#
Aula 02 - Revisão dos Fundamentos

Exercício 02 - Métodos e parâmetros
*/
using System;

namespace Aula02;

public class Exercicio02
{
    public static void Run(){
         Console.Write("Digite seu nome: ");
         string r1 = Console.ReadLine();
         Console.WriteLine($"O seu nome é {r1} e possui {ContarLetras(r1)} caracteres.");

         MostrarDados();
     }

    public static void MostrarDados(){
        Console.WriteLine("Esses são os dados:");
        Console.WriteLine("Rua Teixeira Alves, 43");
        Console.WriteLine("Salvador/BA");
        Console.WriteLine("CEP 04365-080");
    }

    public static int ContarLetras(string palavra="José"){
        return palavra.Length;
    }
}