/*
Curso Básico de C#
Aula 02 - Revisão dos Fundamentos

Exercício 03 - Classes
*/
using System;

namespace Aula02;

public class Pessoa{
    public string Nome;
    public int Idade;
    public char Genero;
    private bool Aprovado = true;

    public void MostrarDados(){
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Aprovado: {Aprovado}");
    }
}

public class Exercicio03
{
    public static void Run(){
        Pessoa p1 = new Pessoa();
        p1.Nome = "Ricardo";
        p1.Idade = 40;
        p1.Genero = 'M';

        p1.MostrarDados();
    }
}
