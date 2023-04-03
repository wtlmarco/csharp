using System;
using System.Threading;

namespace Aula10;

class Aviao : Veiculo {
    public int Passageiros {get;set;}

    public double Altitude {get;set;}
    
    public Aviao(double peso, double altura, double largura, double comprimento, int passageiros) : base(peso, altura, largura, comprimento){
        this.Passageiros = passageiros;
        this.Altitude = 0;

        Console.WriteLine($"Um objeto do tipo Aviao foi criado com densidade {this.Densidade:F2}kg/m3");
    }  

    ~Aviao(){
        Console.WriteLine("Um objeto do tipo Aviao foi destruído.");
    }

    public void Voar(double distancia){
        this.Decolar(1000);
        
        double percorrida = 0;
        
        while(percorrida < distancia){
            Console.WriteLine($"Nosso avião está a {(distancia - percorrida):F2} metros de distância do destino.");

            percorrida += 220;
            Thread.Sleep(1000);
        }
        
        this.Pousar();

        Console.WriteLine("Avião chegou ao destino.");
    }

    private void Pousar(){
        while(this.Altitude > 0){
            Console.WriteLine($"Nosso avião está a {this.Altitude:F2} metros de altitude.");
            this.Altitude -= 60;
            this.Altitude = this.Altitude < 0 ? 0 : this.Altitude;
            Thread.Sleep(1000);
        }
        Console.WriteLine("Pouso concluído.");
        Thread.Sleep(1000);
    }

    private void Decolar(int altitude){
        while(this.Altitude < altitude){
            Console.WriteLine($"Nosso avião está a {this.Altitude:F2} metros de altitude.");

            this.Altitude += 60;
            Thread.Sleep(1000);
        }
        Console.WriteLine("Decolagem concluída.");
        Thread.Sleep(1000);
    }
}