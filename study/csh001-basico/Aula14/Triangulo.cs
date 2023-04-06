using System;

namespace Aula14
{
    class Triangulo
    {
        public double LadoA { get; set; }
        public double LadoB { get; set; }
        public double LadoC { get; set; }

        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            if (ladoA > ladoB + ladoC)
                throw new InvalidTriangleException('A');

            if (ladoB > ladoA + ladoC)
                throw new InvalidTriangleException('B');

            if (ladoC > ladoB + ladoA)
                throw new InvalidTriangleException('C');

            this.LadoA = ladoA;
            this.LadoB = ladoB;
            this.LadoC = ladoC;
        }

        public double ObterArea()
        {
            double semiPerimetro = (this.LadoA + this.LadoB + this.LadoC) / 2;
           
            double area = Math.Sqrt(semiPerimetro *
                (semiPerimetro - this.LadoA) *
                (semiPerimetro - this.LadoB) *
                (semiPerimetro - this.LadoC));

            return area;
        }
    }
}
