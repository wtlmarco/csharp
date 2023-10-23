```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|      Method |     Mean |    Error |   StdDev |   Median |   Gen0 | Allocated |
|------------ |---------:|---------:|---------:|---------:|-------:|----------:|
|       Array | 862.4 ns | 61.66 ns | 177.9 ns | 820.6 ns | 0.5732 |   2.34 KB |
| ArraySealed | 675.3 ns | 37.12 ns | 106.5 ns | 645.8 ns | 0.5732 |   2.34 KB |
