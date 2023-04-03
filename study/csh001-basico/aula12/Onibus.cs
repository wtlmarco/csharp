using System;

namespace Aula12;

public class Onibus : Veiculo {
    private int capacidade;
    public override int Capacidade{
        get{return capacidade;}
        set{
            if((value >= 18) && (value <= 60)){
                capacidade = value;
            }
            else{
                throw new Exception("O onibus pode ter capacidade de 18 a 60 pessoas.");
            }
        }
    }

    public override void Abastecer(double quantidadeLitros){
        QuantidadeCombustivel += quantidadeLitros;

        Console.WriteLine($"Onibus abastecido com {quantidadeLitros} litros de diesel.");
    }

    public override void Mover(double distanciaKm){
        if(QuantidadeCombustivel > (distanciaKm / 5)){
            QuantidadeCombustivel -= (distanciaKm / 5);
            
            Console.WriteLine($"O onibus se moveu por {distanciaKm} kilômetros.");
        }else{
            Console.WriteLine("Não há combustível para percorrer a distância informada.");
        }
    }

    public new void Frear(){
        Console.WriteLine("Acionando os freios a ar... Parou!");
    }

    public Onibus(int pesoKg, DateTime dataFabricacao, int capacidade = 44) : base(pesoKg, dataFabricacao) {
        Capacidade = capacidade;
    }
}