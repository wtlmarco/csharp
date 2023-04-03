using System;

namespace Aula11;

sealed class Aviao : Veiculo{
    public Aviao(double peso) : base(peso){
        Console.WriteLine("Um novo objeto Aviao foi contruído.");
    }

    public override void Mover(double distancia){
        Console.WriteLine($"Um objeto Aviao se moveu por {distancia} km.");
    }
}