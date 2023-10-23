using System.Text;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;

namespace PerformanceTest;

[MemoryDiagnoser]
public class StringConcatBenchmark
{
    int qtde = 1000;

    [Benchmark]
    public string StringBuilderConcat()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < qtde; i++)
        {
            sb.Append("List of itens: " + i);
        }
        return sb.ToString();
    }
    [Benchmark]
    public string GenericListConcat()
    {
        var list = new List<string>(qtde);
        for (int i = 0; i < qtde; i++)
        {
            list.Add("List of itens: " + i);
        }
        return list.ToString();
    }

    [Benchmark]
    public string SimpletConcat()
    {
        string list = "List of itens: ";
        for (int i = 0; i < qtde; i++)
        {
            list += i;
        }
        return list.ToString();
    }
}
