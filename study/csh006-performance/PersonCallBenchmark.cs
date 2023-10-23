using System;
using BenchmarkDotNet.Attributes;

namespace PerformanceTest
{
    [MemoryDiagnoser]
    public class PersonCallBenchmark
    {
        private readonly Programmer _programmer = new ();
        private readonly ProgrammerSealed _programmerSealed = new();

        [Benchmark]
        public void MethodCall()
        {
            _programmer.Eat();
        }

        [Benchmark]
        public void MethodCallSealed()
        {
            _programmerSealed.Eat();
        }
    }
}
