/*
Curso Básico de C#
Aula 01 - Revisão Geral da Linguagem para programadores

Exercício 02 - Recursos de POO
*/
using System;

namespace Aula01;

public class Exercicio02
{
    private static void WriteHeader(){
        Console.WriteLine("Recursos de POO");
        Console.WriteLine("---------------");
    }

    public static void Run()
    {
        WriteHeader();
    }

    public static void InstanciacaoDeClasses()
    {
        //new chama o método construtor da classe
        //e cria uma instância dela na memória
        MinhaClasse1 obj1 = new MinhaClasse1();
        var obj2 = new MinhaClasse2();    
    }

    public static void DefinicaoMembrosDeClasses()
    {
        Pessoa p1 = new Pessoa();
        p1.nome = "Ricardo";
        p1.idade = 40;

        //Chamada de método com valor padrão
        p1.Metodo1(80,185);

        //Chamada de método por referência 
        int peso = 70;
        p1.Metodo2(ref peso,185,"Antonio");

        //Chamada de método por Parâmetro Nomeados
        //Sem obedecer a sequência
        p1.Metodo2(p:ref peso, n: "Cicrano");

        //Sobrecarga de Método
        p1.MostrarDados();
        p1.MostrarDados(true);

        //Conversão de Objetos
        IAnimal a1 = new Cachorro();
        a1.Comer();
        a1.Dormir();
        a1.EmitirSom();
        if(a1 is Cachorro)
            (a1 as Cachorro).Farejar(); 
    }
}

/* Declaração de Classes */

//Sem definição de nível de acesso
//internal - Somente acessado pelas classes compostas no mesmo Assembly
class MinhaClasse1
{
    //membros da classe aqui
}

//Acessado por qualquer classe mesmo externa ao Assembly
public class MinhaClasse2
{
    //membros da classe aqui
}

//Classe que não pode ser instanciada 
//Na verdade 1 estância única é criada automaticamente durante a execução
public static class MinhaClasse3
{
    //membros da classe aqui
}
//------------------------------------------------------------------------

/* Parâmetros de acesso */

//public - acessado por qualquer classe externa
//private - somnente acessado na própria classe
//protected - somente acessado pelas classes descendentes

/* Outros */
// this - Referência a estância atual do objeto dessa classe

public class Pessoa
{
    //Atributos
    public string nome;
    public int idade;
    
    private bool ehEstudante = true;

    //Encapsulamento de Atributos em Propriedades com mecanismo de Leitura e Escrita
    //Permite adicionar uma validação no valor como um Filtro
    //Parâmetro value - representa o valor de entrada
    protected char sexo;
    public char Sexo{
        get{ return this.sexo;} 
        set{
            if(value == 'F' || value == 'M') 
                this.sexo = value;
        }
    }

    //forma compacta de declaração de Propriedades
    public string Endereco { get; set; }

    //Construtores
    //Chamado no momento de se criar a instância do objeto
    //Utilizado para definri os valores padrões dos atributos da classe
    //Pode receber outros parâmetros e repassá-los para o construtor anterior pelo : this()
    public Pessoa(){
        Console.WriteLine("Objeto Pessoa criado.");
    }

    public Pessoa(string _nome, int _idade, char _sexo) : this()
    {
        this.nome = _nome;
        this.idade = _idade;
        this.sexo = _sexo;
    }

    //Destrutor
    //Chamado pelo Garbage Collector quando destroi um objeto na memória
    ~Pessoa()
    {
        Console.WriteLine("Objeto Pessoa destruído.");        
    }
    
    //Métodos
    public void MostrarDados()
    {
        Console.WriteLine($"Nome: {this.nome};");
        Console.WriteLine($"Idade: {this.idade};");
    }

    public void MostrarDados(bool emMaiusculas)
    {
        Console.WriteLine($"Nome: {this.nome.ToUpper()};");
        Console.WriteLine($"Idade: {this.idade.ToString().ToUpper()};");
    }

    /* Declaração de Métodos */
    //1º Modificador de acesso
    //2º Tipo de retorno
    //      void - Método não tem retorno de nenhum valor
    //      int, string, bool,... - Tipos primitivos
    //      Objetos - outras classes estanciadas
    //3º Nome do Método
    //4º Parâmetros de entrada
    // return - utilizado quando 2º tem retorno diferente de void 
    public int Metodo1(int p, int a, string n = "Ciclano")
    {
        return -1;
    }

    //4º Parâmetros de entrada
    //      * Pode ser definido um valor padrão se não for informado na chamada
    //      Deve ser definido no final da lista de parâmentros
    //      * Por Valor - C# usa esse modo como padrão, ou seja, será sempre uma cópia
    //      * Por Referência - ref assim o valor pode ser modificado dentro do método
    //                          precisa ser tb passado por uma variável
    public int Metodo2(ref int p, int a = 170, string n = "Joao")
    {
        return -1;
    }
}

/* Herança de Classes */
//Herança permite acesso aos Métodos, Propriedades e Atributos da classe ancestral
//desde que não sejam declarados como private
//Modificador Protected permite o acesso somente ao Descendente
class Ancestral
{
    private int atributo1;
    public int atributo2;
    protected int atributo3;

    public void Executar(int a){

    }
}

//Método Executar chama o método ancestral pelo modificador : base()
class Descendente1 : Ancestral
{
    public void Executar (int a, string b)
    {

    }
}

//Parâmetro sealed - Classe final que não permite novas heranças a partir dela
sealed class Descentente2 : Ancestral
{

}
//------------------------------------------------------------------------

/* Herança de Classes */
//Classe BASE para outras classes
//Uma classe filha só pode herdar 1 classe abstrata
//1ª Não pode ser instanciada diretamente
//2ª Uma subclasse deve implementar todos os Métodos, Atributos e Propriedades abstratas
//3º Pode conter Métodos, Atributos e Propriedades concretos
abstract class Veiculo{
    public abstract string Placa {get;set;}
    public abstract void MostrarDados();

    protected bool ValidarDocumento()
    {
        return (this.Placa.Length == 6);
    }
}

class Carro : Veiculo{
    public override string Placa {get;set;}
    public override void MostrarDados()
    {
        if(ValidarDocumento())
            Console.WriteLine($"Placa: {this.Placa}.");
    }
}
//------------------------------------------------------------------------

/* Interfaces de Classes */
//Define uma Assinatura da classe
//Permite a Classe utilizar diversas interfaces
interface IAnimal
{
    void Comer();
    void Dormir();
    void EmitirSom();
}

interface IQuadrupede
{
    void Caminhar();
}

class Cachorro : IAnimal, IQuadrupede
{
    public void Caminhar()
    {
        Console.WriteLine("Caminhando...");
    }

    public void Comer()
    {
        Console.WriteLine("Comendo...");
    }

    public void Dormir()
    {
       Console.WriteLine("Dormindo...");
    }

    public void EmitirSom()
    {
        Console.WriteLine("Au au au...");
    }

    public void Farejar()
    {
        Console.WriteLine("Farejando...");
    }
}
//------------------------------------------------------------------------