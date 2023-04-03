/*
Curso Básico de C#
Aula 05 - Estudo de Caso de Cadastro de Produtos

Exercício 02
*/
using System;
using System.Collections.Generic;

namespace Aula05;

public class Exercicio02
{
    private static List<Produto> produtos = new List<Produto>();
    
    private static void WriteHeader(){
        Console.WriteLine("Estudo de Caso de Cadastro de Produtos");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
    
    public static void Run(){
        WriteHeader();

        string comandoEscolhido = "S";

        do{
           //exibição do menu
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("S - Sair");

            //leitura da opção desejada pelo usuário
            Console.Write("Opção desejada: ");
            comandoEscolhido = Console.ReadKey().KeyChar.ToString().ToUpper();

            //processamento do comando digitado pelo usuário
            switch(comandoEscolhido){
                case "1":
                    Console.Write("\nNome do produto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Preço do produto: ");
                    string preco = Console.ReadLine();
                    
                    Produto novoProduto = new Produto(nome, Convert.ToDouble(preco));
                    produtos.Add(novoProduto);
                    
                    Console.WriteLine("Produto adicionado com sucesso!");
                    break;
                case "2":
                    if(produtos.Count > 0){
                        Console.WriteLine("\nListagem de Produtos");
                        
                        foreach(Produto p in produtos){
                            Console.WriteLine(p.ObterTexto());
                        }
                        
                        Console.Write("Pressione qualquer tecla para prosseguir...");
                        Console.ReadKey();
                    }
                    else{
                        Console.WriteLine("\nNão há produtos cadastrados.");
                        Console.ReadKey();
                    }
                    break;
                case "S":
                    Console.WriteLine("\nObrigado por usar o programa.");
                    break;
            default:
                Console.WriteLine("\nOpção inválida! Tente novamente.");
                Console.ReadKey();
                break;
                
            }
        }while(comandoEscolhido != "S");
    }
}