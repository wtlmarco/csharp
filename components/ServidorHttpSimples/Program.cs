using System;

namespace ServidorHttpSimples;

class Program
{
    public static ServidorHttp Servidor {get;set;}

    static void Main(string[] args)
    {  
        Program.Servidor = new ServidorHttp();
        //var servidorHttp = new ServidorHttp();
    }
}