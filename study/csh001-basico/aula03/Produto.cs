using System;

namespace Aula03;

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
}