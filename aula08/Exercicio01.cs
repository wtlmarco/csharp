/*
Curso Básico de C#
Aula 07 - Métodos Sobrecarregados

Exercício 01
*/
using System;

namespace Aula08;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Métodos Sobrecarregados");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Veiculo v1 = new Veiculo("Fusca",CorVeiculo.Preto,2);
        v1.MostrarDados();

        Veiculo v2 = new Veiculo("Opala",CorVeiculo.Vermelho,4); 
        v2.MostrarDados(2);
        v2.Acelerar(5,10);
    }
}