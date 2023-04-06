/*
Curso Básico de C#
Aula 14 - Tratamento de Exceções

Exercício 01 
*/
using System;

namespace Aula14;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Tratamento de Exceções");
        Console.WriteLine("---------------");
        Console.WriteLine();
    }
   
    public static void Run(){
        WriteHeader();

        //DividirNumeroPor(0);

        //AcessarVetor(9);

        //ConverterObjetoParaString(null);
        //ConverterObjetoParaInteiro("abc");

        //ObterPosicaoDePalavraEmTexto("apredendo");
        //ObterPosicaoDePalavraEmTexto(null);

        //ObterArquivoParaEscrita("C:Teste.txt", FileMode.CreateNew);
        //ObterArquivoParaEscrita("C:\\Teste.txt", FileMode.Open);

        //try
        //{
        //    Triangulo t1 = new Triangulo(30, 12, 12);
        //}
        //catch (InvalidTriangleException e)
        //{
        //    Console.WriteLine(e.Message + $"\nLado inválido: {e.WrongSide}");
        //}

        Console.WriteLine(WebCEP.ObterEndereco("01001000"));

        //Linha não executa pq a exceção encerra o programa
        Console.WriteLine("Executou após a Exceção");
    }

    static void DividirNumeroPor(int divisor)
    {
        try
        {
            Console.WriteLine(10 / divisor);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Não é possível dividir por zero.");
        }
    }

    static void AcessarVetor(int indiceElemento)
    {
        string[] palavras = { "Estamos", "aprendendo", "a", "tratar", "exceções","em","C#" };

        try
        {
            Console.WriteLine(palavras[indiceElemento]);
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Não há palavra no índice informado.");
        }
    }

    static void ConverterObjetoParaString(object obj)
    {
        try
        {
            Console.WriteLine(obj.ToString());
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void ConverterObjetoParaInteiro(object obj)
    {
        try
        {
            Console.WriteLine(Convert.ToInt32(obj));

            Console.WriteLine((int)obj);
        }
        catch(Exception e)
        {
            if(e is FormatException || e is InvalidCastException)
                Console.WriteLine($"O objeto passado como parâmetro não pode ser convertido para Inteiro");
        }
    }

    static void ObterPosicaoDePalavraEmTexto(string palavra)
    {
        string texto = "Estamos aprendendo a tratar as exceções em C#";

        try
        {
            Console.WriteLine(texto.IndexOf(palavra));
        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine($"Ocorreu um erro: {e.Message}\n Código do erro: {e.HResult}.");
        }
    }

    static StreamWriter ObterArquivoParaEscrita(string caminho, FileMode mode)
    {
        if(caminho is null)
        {
            Console.WriteLine("Você não informou um caminho para o arquivo.");
        }

        try
        {
            var fs = new FileStream(caminho, mode);
            return new StreamWriter(fs);
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("O arquivo não pode ser encontrado.");
        }
        catch(DirectoryNotFoundException)
        {
            Console.WriteLine("O diretório não pode ser encontrado.");
        }
        catch(DriveNotFoundException)
        {
            Console.WriteLine("O disco não pode ser encontrado.");
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("O caminho do arquvo excede o tamanho máximo suportado.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("você não tem permissão para acessar o arquivo.");
        }
        catch(IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            Console.WriteLine("Há uma violação de compartilhamento do arquivo.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
        {
            Console.WriteLine("O arquivo já existe.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Uma exceção ocorreu:\nCódigo do erro:" +
                $"{e.HResult & 0x0000FFFF}\nMensagem: {e.Message}");
        }
       
        return null;
    }
}