using System;

namespace Aula12;

public class Carro : Veiculo {
    private int capacidade;
    public override int Capacidade{
        get{return capacidade;}
        set{
            if((value >= 2) && (value <= 7)){
                capacidade = value;
            }
            else{
                throw new Exception("O carro pode ter capacidade de 2 a 7 pessoas.");
            }
        }
    }

    public int PotenciaCv {get;set;}

    public override void Abastecer(double quantidadeLitros){
        QuantidadeCombustivel += quantidadeLitros;

        Console.WriteLine($"Carro abastecido com {quantidadeLitros} litros de gasolina.");
    }

    public override void Mover(double distanciaKm){
        if(QuantidadeCombustivel > (distanciaKm / 10)){
            QuantidadeCombustivel -= (distanciaKm / 10);
            
            Console.WriteLine($"O carro se moveu por {distanciaKm} kilômetros.");
        }else{
            Console.WriteLine("Não há combustível para percorrer a distância informada.");
        }
    }

    public override void Frear(){
        Console.WriteLine("Acionando os freios ABS... Parou!");
    }

    public Carro(int pesoKg, DateTime dataFabricacao, int capacidade = 5) : base(pesoKg, dataFabricacao) {
        Capacidade = capacidade;
    }
}