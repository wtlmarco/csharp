using System;
using System.Text;

namespace Aula07;

class Carro : Veiculo{
    public int Portas{get;set;}

    public double Preco {get;set;}

    public string Modelo {get;set;}

    public Carro(){
        Console.WriteLine("Um novo objeto do tipo Carro foi criado.");  
    }

    public Carro(int pesoKg) : base(pesoKg){
        Console.WriteLine($"Um novo objeto do tipo Carro com peso {this.PesoKg} foi criado.");
    }
    
    public Carro(string modelo) : this(){
        this.Modelo = modelo;
    }
    
    public Carro(string modelo, int portas, double preco) : this(modelo){
        this.Portas = portas;
        this.Preco = preco;
    }

    ~Carro(){
        Console.WriteLine("Um objeto do tipo Carro foi destruído");
    }
}