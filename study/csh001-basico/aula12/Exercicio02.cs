/*
Curso Básico de C#
Aula 12 - Implementando Polimorfismo

Exercício 02
*/
using System;
using System.Collections.Generic;

namespace Aula12;

public class Exercicio02
{
    static List<Veiculo> veiculos = new List<Veiculo>();
    static Random random = new Random();
    
    private static void WriteHeader(){
        Console.WriteLine("Implementando Polimorfismo");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        CriarVeiculosAleatorios();

        foreach(var v in veiculos){
            Console.WriteLine("--------------------------");
            Console.WriteLine(v.Tipo);
            v.Abastecer(random.Next(10,60));
            v.Mover(random.Next(10,200));
            v.Frear();
        }

        Console.WriteLine("--------------------------");
    }

    static void CriarVeiculosAleatorios(){
        for(int i=0; i< 10; i++){
            if(random.Next() % 2 == 0){
                veiculos.Add(new Carro(random.Next(800,1400), DateTime.Now.Date.AddDays(-random.Next(30, 3600))));
            }else{
                veiculos.Add(new Onibus(random.Next(3000,12000), DateTime.Now.Date.AddDays(-random.Next(30, 3600))));
            }
        }
    }
}