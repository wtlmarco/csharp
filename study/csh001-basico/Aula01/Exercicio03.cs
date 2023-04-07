/*
Curso Básico de C#
Aula 01 - Revisão Geral da Linguagem para programadores

Exercício 03 - Tópicos Avançados de C#
*/
using System;

namespace Aula01;

public class Exercicio03
{
    private static void WriteHeader(){
        Console.WriteLine("Tópicos Avançados de C#");
        Console.WriteLine("---------------");
    }

    public static void Run()
    {
        WriteHeader();

        
    }

    //Generics
    //Cria coleções fortemente tipadas
    public static void ColecoesGenericas(){
        var obj = new Transporte();

        //Lista Encadeada
        List<Transporte> lista = new List<Transporte>();
        lista.Add(obj);
        Transporte t0 = lista[0];
        lista.Clear();
        lista.Count();
        lista.Contains(obj);
        
        //Fila
        //Primeiro que entra é o primeiro que sai
        Queue<Transporte> fila = new Queue<Transporte>();
        fila.Enqueue(obj);
        Transporte t1 = fila.Dequeue();
        fila.Clear();
        fila.Count();
        fila.Contains(obj);

        //Pilha
        //O último que entra é o primeiro que sai
        Stack<Transporte> pilha = new Stack<Transporte>();
        pilha.Push(obj);
        Transporte t2 = pilha.Pop();
        pilha.Clear();
        pilha.Count();
        pilha.Contains(obj);

        //Chave e Valor
        Dictionary<string, Transporte> dicionario = new Dictionary<string, Transporte>();
        dicionario.Add("Totó",obj);
        Transporte t3 = dicionario["Totó"];
        dicionario.Clear();
        dicionario.Count();
        dicionario.ContainsKey("Totó");
        dicionario.ContainsValue(obj);

        //Chave e Valor ordenado
        SortedList<string, Transporte> ordenada = new SortedList<string, Transporte>();
        ordenada.Add("Scooby",obj);
        Transporte t4 = ordenada["Scooby"];
        ordenada.Clear();
        ordenada.Count();
        ordenada.ContainsKey("Scooby");
        ordenada.ContainsValue(obj);
    }
    
    //LINQ
    //adiciona funcionalidades de consulta em algumas linguagens de programação
    ///Is LINQ faster than for loop?
    //LINQ syntax is typically less efficient than a foreach loop. It's good to be aware of any
    //performance tradeoff that might occur when you use LINQ to improve the readability of your code.
    public static void LINQAgregadas()
    {
        List<Prova> provas = new List<Prova>();

        var soma = provas.Sum(p => p.Nota);
        var qtdeAprovadas = provas.Count(p => p.Nota > 6);
        var media = provas.Average(p => p.Nota);
        var maior = provas.Max(p => p.Nota);
        var menor = provas.Min(p => p.Nota);
    }

    public static void LINQOrdenacaoPaginacao()
    {
        List<Prova> provas = new List<Prova>();

        var ordAlu = provas.OrderBy(p => p.Aluno.Nome);
        var ordDis = provas.OrderBy(p => p.Disciplina.Nome);
        var ordInv = provas.OrderByDescending(p => p.Nota);
        
        var salto = provas.Skip(15);
        var pagina = salto.Take(5);
        var pagina4 = provas.Skip(15).Take(5);
    }

    public static void LINQOFiltros()
    {
        List<Prova> provas = new List<Prova>();

        var provasMat = provas.Where(p => p.Disciplina.Nome.Equals("Matemática"));

        var provasFulano = provas.Where(p => p.Aluno.Nome.Equals("Fulano"));

        var aprovados = provas.Where(p => p.Nota > 6);

        var maior = provas.Max(p => p.Nota);
        var melhorAluno = provas.SingleOrDefault(p => p.Nota == maior).Aluno;

        var mediaMat = provas.Where(p => p.Disciplina.Nome.Equals("Matematica")).Average(p => p.Nota);
    }
}

class Transporte
{}

/*Modelo de Dados*/
class Aluno
{
    public string Nome { get; set; } 
}

class Disciplina
{
    public string Nome { get; set; } 
}

class Prova
{
    public Disciplina Disciplina { get; set; }
    public Aluno Aluno { get; set; }
    public DateTime DataHora { get; set; }
    public double Nota { get; set; }
    public double Peso { get; set; } 
}