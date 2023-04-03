using System;

namespace Aula07;

class Veiculo{
    public int PesoKg{get;set;}

    public Veiculo(){
        Console.WriteLine("Um objeto tipo Veículo foi criado.");
    }

    public Veiculo(int pesoKg) : this(){
        this.PesoKg = pesoKg;
    }

    ~Veiculo(){
        Console.WriteLine("Um objeto tipo Veículo foi destuído com sucesso.");
    }
}