using System;

namespace Aula14
{
    class InvalidTriangleException : Exception
    {
        const string mensagemErro = "Um dos lados do triângulo excede o tamanho máximo permitido.";

        public char WrongSide { get; }

        public InvalidTriangleException(char wrongSide) : base(mensagemErro)
        {
            this.HelpLink = @"https://www.stoodi.com.br/blog/matematica/triangulo/";
            this.WrongSide = wrongSide;
        }
    }
}
