using System;

namespace Aula11;

class Carro : Veiculo {
    public Carro(double peso): base(peso){}
       
    public override void Mover(double distancia){
          Console.WriteLine($"Um objeto Carro se moveu por {distancia} km.");
    } 
}