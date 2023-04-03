/*
Curso Básico de C#
Aula 02 - Revisão dos Fundamentos

Exercício 01 - Tipos, controles lógicos e de repetição
*/
using System;

namespace Aula02;

public class Exercicio01
{
    public static void Run(){
        int n1 = 3;
        double n2 = 3.4;
        string s1 = "Lorem Ipsum";
        char c1 = '@';
        
        Console.WriteLine(n1);
        Console.WriteLine(n2);
        Console.WriteLine(s1);
        Console.WriteLine(c1);
        Console.WriteLine($"{n1},{n2},{s1},{c1}");

        double n3 = n1+n2;
        Console.WriteLine($"A soma é {n3:F4}.");

        n3 += 5;
        Console.WriteLine($"A nova soma é {n3:F4}.");

        bool ehPar = (n1 % 2 == 0);
        if(ehPar){
            Console.WriteLine("O número é par");    
        }
        else{
            Console.WriteLine("O número é ímpar");
        }

        switch(n1){
        case 1:
            Console.WriteLine("O valor é 1.");
            break;
        case 2:
            Console.WriteLine("O valor é 2.");
            break;
        case 3:
            Console.WriteLine("O valor é 3.");
            break;
        case 4:
            Console.WriteLine("O valor é 4.");
            break;
        default:
            Console.WriteLine("O valor não está entre 1 e 4.");
            break;
        }

        int i=0;
        while(i<=10){
            Console.WriteLine($"Iteração {i}.");
            
            if(i == 5) {
                Console.WriteLine("Repetição finalizada!");
                break;
            }

            i++;
        }

        for(int j=0; j<10;j++){
            if(j == 5) {
                Console.WriteLine($"Iteração {j} -- pulada.");
                continue;
            }

            Console.WriteLine($"Iteração {j}.");
            
            if(j == 8) {
                Console.WriteLine("Repetição finalizada!");
                break;
            }
        }

        i = 10;
        do{
            i--;
            if(i == 5) {
                Console.WriteLine($"Iteração {i} -- pulada.");
                continue;
            }

            Console.WriteLine($"Iteração {i}.");
        }while(i>0);
    }
}