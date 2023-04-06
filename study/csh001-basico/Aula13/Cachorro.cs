using System;

namespace Aula13;

class Cachorro : IAnimal, IQuadrupede
{
    void IAnimal.Andar()
    {
        Console.WriteLine("O cachorro est� andando com as quatro patas.");
    }

    void IQuadrupede.Andar()
    {
        Console.WriteLine("O cachorro est� andando com as quatro patas.");
    }

    public void Correr()
    {
        Console.WriteLine("O cachorro est� correndo com as quatro patas.");
    }

    public void Comer()
    {
        Console.WriteLine("O cachorro est� comendo ra��o.");
    }

    public void Dormir()
    {
        Console.WriteLine("O cachorro est� dormindo no ch�o.");
    }

    public void EmitirSom()
    {
        Console.WriteLine("Au au au");
    }

    public void Farejar()
    {
        Console.WriteLine("O cachorro est� farejando.");
    }
}