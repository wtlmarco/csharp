using System;
using System.Text;

namespace Aula05;

class Produto{
    private string nome;
        
    public string Nome{
        get{
            return nome;
            }
        
        set{
            if(value.Length > 1)
                nome = value;
            else
                throw new Exception("Nome do Produto deve ter pelo menos 2 caracteres.");
            }
    }
    
    public double Preco{get;set;}

    public int Estoque{get; private set;}

    public Produto(){
        this.Estoque = 0;
    }

    public Produto(string nome, double preco){
        this.Nome = nome;
        this.Preco = preco;
        this.Estoque = 0;
    }

    public int Vender(int qtde){
        if(this.Estoque - qtde >= 0)
            this.Estoque -= qtde;

        return this.Estoque;
    }

    public int Comprar(int qtde){
        this.Estoque += qtde;
        return this.Estoque;
    }

    public string ObterTexto(){
        StringBuilder sb = new StringBuilder();
        sb.Append($"\nNome: {this.Nome}\n");
        sb.Append($"Preço: {this.Preco}\n");
        sb.Append($"Estoque: {this.Estoque}\n");
        
        return sb.ToString();
    }
}