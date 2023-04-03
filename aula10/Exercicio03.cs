/*
Curso Básico de C#
Aula 10 - Herança de Classes

Exercício 03 - Diferença de acesso entre objeto Pai e objeto Herdado
*/
using System;

namespace Aula10;

public class Exercicio03
{
    private static void WriteHeader(){
        Console.WriteLine("Herança de Classes");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Veiculo a1 = new Aviao(3200, 4, 16, 12, 12);
        //a1.Voar(1000); ***Erro de acesso ao método

        Barco b1 = new Barco(1200, 2.5, 4, 12, 800);
        b1.Navegar(200);
    }
}