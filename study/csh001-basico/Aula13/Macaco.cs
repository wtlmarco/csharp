using System;

namespace Aula13
{
    public class Macaco : IAnimal, IBipede
    {
        public void Andar()
        {
            Console.WriteLine("O macaco está andando com os dois pés");
        }

        public void Caminhar()
        {
            Console.WriteLine("O macaco está andando com os dois pés.");
        }

        public void Comer()
        {
            Console.WriteLine("O macaco está comendo banana.");
        }

        public void Dormir()
        {
            Console.WriteLine("O macaco está dormindo na árvore.");
        }

        public void EmitirSom()
        {
            Console.WriteLine("Ua uh ah ah ah.");
        }
    }
}
