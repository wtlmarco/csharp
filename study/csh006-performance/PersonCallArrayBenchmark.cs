using BenchmarkDotNet.Attributes;
using PerformanceTest;

[MemoryDiagnoser]
public class PersonCallArrayBenchmark
{
    private readonly Programmer[] _array = new Programmer[100];
    private readonly ProgrammerSealed[] _sealedArray = new ProgrammerSealed[100];

    [Benchmark]
    public void Array()
    {
        for (var i = 0; i < _array.Length; i++)
        {
            _array[i] = new Programmer();

            _array[i].Eat();
        }
    }

    [Benchmark]
    public void ArraySealed()
    {
        for (var i = 0; i < _sealedArray.Length; i++)
        {
            _sealedArray[i] = new ProgrammerSealed();

            _sealedArray[i].Eat();
        }
    }
}