using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace PerformanceTest;

[InProcess()]
[MemoryDiagnoser]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
[GcServer(true)]
public class FibonacciBenchmark
{
    [Params(1, 2, 3, 5, 8, 13, 21, 34)]
    public int Count { get; set; }

    [Benchmark]
    public void Fibonacci()
    {
        var xs = Count.GetFibonacci().ToList();
    }
}

public static class NumbersExtends
{
    public static IEnumerable<int> GetFibonacci(this int count)
    {
        var w = 1;
        var x = 1;

        yield return x;
        foreach (var _ in Enumerable.Range(1, count - 1))
        {
            var y = w + x;
            yield return y;
            w = x;
            x = y;
        }
    }
}


