using BenchmarkDotNet.Attributes;

namespace PerformanceTest;

[MemoryDiagnoser]
[RankColumn]
public class SerializeObjectBenchmark
{
    private Regiao[] _regioes;

    [GlobalSetup]
    public void Setup()
    {
        _regioes = new Regiao[]
        {
            new () { Codigo = "CO", Nome = "Centro-Oeste" },
            new () { Codigo = "NE", Nome = "Nordeste" },
            new () { Codigo = "N", Nome = "Norte" },
            new () { Codigo = "SE", Nome = "Sudeste" },
            new () { Codigo = "S", Nome = "Sul" }
        };
    }

    [Benchmark]
    public string SerializeWithNewtonsoft()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_regioes);
    }

    [Benchmark]
    public string SerializeWithSystemTextJson()
    {
        return System.Text.Json.JsonSerializer.Serialize(_regioes);
    }
}

public class Regiao
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
}