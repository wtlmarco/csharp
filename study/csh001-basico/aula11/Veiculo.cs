using System;

namespace Aula11;

public abstract class Veiculo {
    public double Peso {get;set;}

    public Veiculo(double peso){
        this.Peso = peso;

        Console.WriteLine("Um novo objeto Veiculo foi contruído.");
    }

    ~Veiculo(){
        Console.WriteLine("Um novo objeto Veiculo foi destruído.");
    }

    public abstract void Mover(double distance);
}