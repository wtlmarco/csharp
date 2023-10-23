using System;

namespace PerformanceTest;

public class Person
{
    public virtual void Eat()
    {
        
    }
}

public class Programmer: Person
{
    public override void Eat()
    {

    }
}

public sealed class ProgrammerSealed : Person
{
    public override void Eat()
    {

    }
}

