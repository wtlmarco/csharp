using System;
using System.Threading;

namespace Aula08;

enum CorVeiculo{Branco, Preto, Vermelho, Prata, Grafite};

class Veiculo{
    public string Modelo{get;set;}

    public string Peso{get;set;}

    public double Velocidade{get;set;}

    public int Portas{get;set;}

    public CorVeiculo Cor{get;set;}

    public Veiculo(string modelo){
        this.Velocidade = 0;
        this.Modelo = modelo;
    }

    public Veiculo(string modelo, CorVeiculo cor):this(modelo){
        this.Cor = cor;
    }

    public Veiculo(string modelo, CorVeiculo cor, int portas = 4):this(modelo,cor){
        this.Portas = portas;
    }

    public void MostrarDados(){
        Console.WriteLine($"Veículo {this.Modelo} :: Cor {this.Cor} :: {this.Portas} Portas");
    }

    public void MostrarDados(int nroLinha){
        Console.WriteLine($"{nroLinha}, Veículo {this.Modelo} :: Cor {this.Cor} :: {this.Portas} Portas");
    }

    /// <summary>
    /// Método utilizado para aumentar a velocidade do veículo
    /// </summary>
    public void Acelerar(){
        this.Velocidade += 10;
    }

    /// <summary>
    /// Método utilizado para aumentar a velocidade do veículo
    /// </summary>
    /// <param name="acrescimo">Quantidade a ser aumentada</param>
    public void Acelerar(int acrescimo){
        this.Velocidade += acrescimo;
    }

    /// <summary>
    /// Método utilizado para aumentar a velocidade do veículo
    /// </summary>
    /// <param name="acrescimo">Quantidade a ser aumentada</param>
    /// <param name="tempoSeg">Tempo para aumento</param>
    public void Acelerar(int acrescimo, double tempoSeg){
        DateTime inicio = DateTime.Now;
        DateTime fim = inicio.AddSeconds(tempoSeg);

        while(inicio < fim){
            this.Velocidade += acrescimo;

            Thread.Sleep(1000);
            
            Console.WriteLine($"Velocidade Atual: {this.Velocidade:F2}");

           inicio = inicio.AddSeconds(1);
        }
    }
}