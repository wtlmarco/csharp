using System;

namespace Aula12;

public abstract class Veiculo {
    public int PesoKg {get;set;}

    public DateTime DataFabricacao {get;set;}

    public double QuantidadeCombustivel {get;set;}

    public string Tipo {get{ return this.GetType().Name; }}

    public abstract int Capacidade {get; set;}

    public abstract void Abastecer(double quantidadeLitros);

    public abstract void Mover(double distanciaKm);

    public virtual void Frear(){
        Console.WriteLine("Acionando os freios... Parou!");
    }

    public Veiculo(int pesoKg, DateTime dataFabricacao){
        this.PesoKg = pesoKg;
        this.DataFabricacao = dataFabricacao;
    }
}