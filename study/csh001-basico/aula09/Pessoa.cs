using System;

namespace Aula09;

class Pessoa{
    private string cpf;

    public string CPF{
        get{return cpf;}
        set{
            if(value.Length == 11 && value.HasOnlyDigits())
                cpf = value;
            else
                throw new Exception("O CPF deve possuir 11 dígitos.");
        }
    }

    public string Nome {get;set;}

    public string Sobrenome {get;set;}

    public DateTime Nascimento {get;set;}

    public double Peso {get;set;}

    public double Altura {get;set;}

    public double IMC{
        get{
            return (this.Peso / (this.Altura * this.Altura));
        }
    }

    public Pessoa(string nome, string sobrenome, DateTime nascimento, string cpf){
        this.Nome = nome;
        this.Sobrenome = sobrenome;
        this.Nascimento = nascimento;
        this.CPF = cpf;
    }

    public Pessoa(string nome, string sobrenome, DateTime nascimento, string cpf, double peso, double altura) : this(nome,sobrenome,nascimento,cpf){
        this.Peso = peso;
        this.Altura = altura;
    }

    public void Comer(double pesoKg){
        this.Peso += pesoKg / 10;

        Console.WriteLine($"{this.Nome} {this.Sobrenome} comeu {pesoKg}kg de comida.");
    }

    public void Comer(int calorias){
        this.Peso += calorias / 30000;

        Console.WriteLine($"{this.Nome} {this.Sobrenome} ingeriu {calorias} calorias.");
    }

    public void Correr(double distanciaKm, int dias = 1){
        this.Peso -= (distanciaKm / 40) * dias;

        Console.WriteLine($"{this.Nome} {this.Sobrenome} correu {distanciaKm} kms diários por {dias} dia(s).");
    }

    public void MostrarDados(){
        Console.WriteLine($"Nome completo: {this.Nome} {this.Sobrenome}");
        Console.WriteLine($"Idade: {Math.Truncate((DateTime.Now - this.Nascimento).TotalDays / 365.25)} anos");
        Console.WriteLine($"IMC: {this.IMC:F2}");
    }
}