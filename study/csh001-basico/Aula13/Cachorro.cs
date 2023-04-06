using System;

namespace Aula13;

class Cachorro : IAnimal, IQuadrupede
{
    void IAnimal.Andar()
    {
        Console.WriteLine("O cachorro está andando com as quatro patas.");
    }

    void IQuadrupede.Andar()
    {
        Console.WriteLine("O cachorro está andando com as quatro patas.");
    }

    public void Correr()
    {
        Console.WriteLine("O cachorro está correndo com as quatro patas.");
    }

    public void Comer()
    {
        Console.WriteLine("O cachorro está comendo ração.");
    }

    public void Dormir()
    {
        Console.WriteLine("O cachorro está dormindo no chão.");
    }

    public void EmitirSom()
    {
        Console.WriteLine("Au au au");
    }

    public void Farejar()
    {
        Console.WriteLine("O cachorro está farejando.");
    }
}