/*
Curso Básico de C#
Aula 01 - Revisão Geral da Linguagem para programadores

Exercício 01 - Fundamentos de C#
*/
using System;

namespace Aula01;

public class Exercicio01
{
    private static void WriteHeader(){
        Console.WriteLine("Métodos Construtores e Métodos Comuns");
        Console.WriteLine("---------------");
    }

    public static void Run()
    {
        WriteHeader();
    }

    public static void TiposDeComentarios()
    {
    Console.WriteLine("Fundamentos de C#"); //Comentário de fim de linha

    //Comentário de 1 Linha
    Console.WriteLine("Fundamentos de C#");

    /*
    Linha de comentário 1
    Linha de comentário 2
    Linha de comentário 3
    */
    Console.WriteLine("Fundamentos de C#");
    }

    public static void DeclaracaoDeVariaveis()
    {
        //inicializadas
        int idade = 5;

        //não inicializadas
        int ano;
        ano = 2021;

        //várias na mesma linha
        int anpNascimento = 2021, idadeAtual = 25;

        //constantes
        const int umaDuzia = 12;
    }

    public static void TiposDeDadosPrimitivosInteiros()
    {
        //Com sinal
        sbyte v1 = 127;
        //-128 a 127 (8 bits, System.SByte)

        short v2 = 32767;
        //-32.768 a 32.767 (16 bits, System.Int16)

        int v3 = 2147483647;
        //-2.147.483.648 a 2.147.483.647 (32 bits, System.Int32)

        long v4 = 9223372036854775807;
        //-9.223.372.036.854.775.808 a 9.223.372.036.854.775.808 (64 bits, System.Int64)

        //Sem sinal
        byte v5 = 255; //System.Byte

        ushort v6 = 65535; //System.UInt16

        uint v7 = 4294967295; //System.UInt32

        ulong v8 = 18_446_744_073_709_551_615; //System.UInt64
    }

    public static void AtribuirValoresInteirosLiterais()
    {
        int binario = 0b00100001; //33
        int hexadec = 0x2A; //42
    }

    public static void TipoDeDadosPrimitivosPontoFlutuantes()
    {
        float v1 = 0.1234567890F;
        //6 a 9 dígitos, 4 bytes, System.Single
        //+-1,5 x 10^-45 a +-3,4 x 10^38

        double v2 = 0.123456789012345678;
        //15 a 17 dígitos, 8 bytes, System.Double
        //+-5,0 x 10^-324 a +-1,7 x 10^308

        decimal v3 = 0.123456789012345678901234567890M;
        //28 a 29 dígitos, 16 bytes, System.Decimal
        //+-1,0 x 10^-28 a +-7,9228 x 10^28

        //notação científica
        double v4 = 1.55e2; //1.55 x 10^2 = 155
    }

    public static void TipoDeDadosPrimitivosNaoNumericos()
    {
        bool aproado = true;
        //true ou false, System.Boolean

        char conceito = 'A';
        //1 caractere Unicode UTF-16, System.Char

        string assunto = "Programação";
        //vetor de char, System.String
    }

    public static void ConversaoDeTiposImplicita()
    {
        //System.Int16
        short n1 = 259;

        //System.Int32
        int n2 = n1;

        //System.Double
        double n3 = n2;
    }
    public static void ConversaoDeTiposExplicita()
    {
        //System.Double
        double n4 = 25.45;

        //System.Int32
        int n5 = (int)n4;

        //System.Int16
        short n6 = (short)n5;
    }
    public static void ConversaoDeTiposComMetodos()
    {
        //System.Double
        double n1 = 25.55;

        //System.Int32
        int n2 = (int)n1; //Número é truncado para 25 descartando o número após o ponto

        //System.Int32
        int n3 = Convert.ToInt32(n1); // Faz o arredondamento para o maior ou menor, no caso 26

        string s1 = "10,77";
        double n4 = Convert.ToDouble(s1); //Entre tipos diferentes, a conversão somente por método
    }
    public static void TipagemAutomatica()
    {
        var v1 = 25; //int
        
        var v2 = "Texto"; //string

        var v3 = 7.45; //double

        var v4 = true; //bool

        var v5 = 'C'; //char
    }

    public static void EntradaDeDadosViaTerminal()
    {
        //lê até pressionar ENTER
        string e1 = Console.ReadLine();
        double n1 = Convert.ToDouble(e1);

        string e2 = Console.ReadLine();
        //int n2 = (int)e2; //não aceita
        int n2 = Convert.ToInt32(e2);

        //lê somente uma tecla
        ConsoleKeyInfo tecla = Console.ReadKey();
        Console.WriteLine(tecla.KeyChar);
        //(tecla.Modifiers & ConsoleModifiers.Shift) != 0
    }
    public static void OperadoresAritmeticos()
    {
        int x = 9;
        int y = 5;
        int r1 = x + y; //14
        int r2 = x - y; //4
        int r3 = x * y; //45

        float r4 = x / y; //1
        float r5 = x / (float)y; //1.8
        int r6 = x % y; //4
        y++; //6
        y--; //5

        string texto = "Fundamentos de " + "C#";
        texto = texto + x;
    }
    public static void OperadoresParaBits()
    {
        int x = 5;          //0101
        int y = 3;          //0011
        int r1 = x & y;     //0001 = 1
        int r2 = x | y;     //0111 = 7
        int r3 = x ^ y;     //0110 = 6
        int r4 = x >> y;    //0000 = 0
        int r5 = x << y;    //0010_1000 = 40
        uint z = 0b_0101;   //5
        uint r6 = ~z;       //1..1010
    }
    public static void OperadoresDeAtribuicao()
    {
        double x = 9.4;
        x += 5; //14.4
        x -= 4; //10.4
        x *= 5; //52
        x /= 5.0; //10.4
        x %= 5; //0.4

        int y = 5;
        y &= 3; //y = y & 3
        y |= 3; //y = y | 3
        y ^= 3; //y = y ^ 3
        y >>= 3; //y = y >> 3
        y <<= 3; //y = y << 3
    }
    public static void OperadoresDeComparacao()
    {
        int x = 5;
        int y = 3;
        bool b1 = x == y; //false
        bool b2 = x != y; //true
        bool b3 = x > y; //true
        bool b4 = x < y; //false
        bool b5 = x >= y; //true
        bool b6 = x <= y; //false
    }
    public static void OperadoresLogicos()
    {
        bool b1 = false;
        bool b2 = true;
        bool b3 = b1 && b2; //AND
        bool b4 = b1 || b2; //OR
        bool b5 = b1 & b2; //AND-Otimizado
        bool b6 = b1 | b2; //OR-Otimizado
        bool b7 = b1 ^ b2; //XOR
        bool b8 = !b1; //true
    }
    public static void OperacoesSobreStrings()
    {
        string texto = "Este é um texto qualquer.";
        
        int tamanho = texto.Length;
        
        string maiusculas = texto.ToUpper();
        string minusculas = texto.ToLower();
        
        int posEh = texto.IndexOf("é");
        
        string trecho = texto.Substring(0,4);
        
        string aspas = "\"" + texto + "\"";
        string caminho = "C:\\Temp\\Arquivo.txt";
        string quebra = "Fim da linha.\n";
        string tabulacao = "Coluna1\tColuna2\tColuna3";
        string interpolada = $"Frase: {texto}";

    }
    public static void EstruturasCondicionais()
    {
        int x = 5;
        if(x > 3)
        {
            Console.WriteLine("Maior");
        }

        int y = 5;
        if(y > 3)
        {
            Console.WriteLine("Maior");
        }
        else
        {
            Console.WriteLine("Menor");
        }

        int z = 5;
        if(z > 3)
        {
            Console.WriteLine("Maior");
        }
        else if(z < 3)
        {
            Console.WriteLine("Menor");
        }
        else
        {
            Console.WriteLine("Igual");
        }
    }
    public static void EstruturasCondicionaisAninhadas(bool el1, bool el2)
    {
        if(el1)
        {
            if(el2) //Não precisa de chaves se for seguida de única linha
                Console.WriteLine("el1 e el2 verdadeiras.");
        }
        else
        {
            Console.WriteLine("el1 falsa.");
        }
    }
    public static void EstruturaDeSelecaoMultipla()
    {
        Random rndm = new Random();

        int diaDaSemana = rndm.Next(1,8);
        switch (diaDaSemana
        )
        {
            case 1:
                Console.WriteLine("Domingo");
                break;
            case 2:
                Console.WriteLine("Segunda");
                break;
            case 3:
                Console.WriteLine("Terça");
                break;
            case 4:
                Console.WriteLine("Quarta");
                break;
            case 5:
                Console.WriteLine("Quinta");
                break;
            case 6:
                Console.WriteLine("Sexta");
                break;
            case 7:
                Console.WriteLine("Sábado");
                break;
            default:
                Console.WriteLine("Inválido");
                break;
        }
    }
    public static void EstruturaDeRepeticao(bool el1, bool el2)
    {
        while (el1)
        {
            //operacoes
        }

        do//Executa pelo menos 1 vez
        {

        }while(el2);

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(i);
        }

        string[] tags = {"c#", ".net", "vs code"};
        foreach (string tag in tags)//Estrutura para percorrer coleções
        {
            Console.WriteLine(tag);
        }
    }
    public static void InterrupcaoDeIteracoes()
    {
        for (int i = 0; i < 10; i++)
        {
            if(i == 4)
                break;
            
            Console.Write(i + ","); //0,1,2,3,
        }

        for (int i = 0; i < 10; i++)
        {
            if(i == 4)
                continue;
            
            Console.Write(i + ","); //0,1,2,3,5,6,7,8,9
        }
    }
    public static void Vetores()
    {
        //Tamanho dos Vetores são imutáveis

        int[] primos = {2,3,5,7,11,13,17,19};
        
        string[] tags1 = {"C#","Java","JavaScript","Python"};
        
        string[] tags2 = new string[] {"C#","Java","JavaScript","C"};
        
        string[] tags3 = new string[4] {"C#","Java","JavaScript","C"};
        
        string[] tags4 = new string[4];
        tags4 = new string[] {"C#","Java","JavaScript","C"};
        tags4 = new string[4] {"C#","Java","JavaScript","C"};
    }
    public static void VetoresAcessandoElementos()
    {
        string[] tags = {"C#","Java","JavaScript","Python"};
        
        tags[3] = "C++";
        Console.WriteLine(tags[1]);

        for (int i = 0; i < tags.Length; i++)//Maior controle das iterações
        {
            Console.WriteLine(tags[i]);
        }

        foreach (string tag in tags)
        {
            Console.WriteLine(tag);
        }
    }
    public static void VetoresMetodosUteis()
    {
        string[] tags = {"C#","Java","JavaScript","Python"};
        Array.Sort(tags);
        //using System.LINQ
        
        int[] primos = {2,3,5,7,11,13,17,19};
        Console.WriteLine(primos.Max());
        Console.WriteLine(primos.Min());
        Console.WriteLine(primos.Sum());
        Console.WriteLine(primos.Average());
        Console.WriteLine(primos.Count());
    }
    enum Semaforo //Sempre declarado fora do método
    {
        Vermelho,
        Amarelo,
        Verde
    }
    public static void TiposEnumerados()
    {
        Semaforo s1 = Semaforo.Verde;

        foreach (Semaforo item in Enum.GetValues(typeof(Semaforo)))
        {
            Console.WriteLine((int)item);
        }//0,1,2
    }
    enum diaDaSemana{
            Segunda         = 0b_0000_0001,//1
            Terca           = 0b_0000_0010,//2
            Quarta          = 0b_0000_0100,//4
            Quinta          = 0b_0000_1000,//8
            Sexta           = 0b_0001_0000,//16
            Sabado          = 0b_0010_0000,//32
            Domingo         = 0b_0100_0000,//64
            FimDeSemana     = Sabado | Domingo
        }
}