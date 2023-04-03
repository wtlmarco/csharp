/*
Curso Básico de C#
Aula 11 - Classes Abstratas e Membros Abstratos

Exercício 01 
*/
using System;
namespace Aula11;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Classes Abstratas e Membros Abstratos");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        Carro c1 = new Carro(1200);
        Aviao a1 = new Aviao(3000);

        ViajarParaCalifornia(a1);
    }

    static void ViajarParaCalifornia(Veiculo v){
        v.Mover(10000);
    }
}