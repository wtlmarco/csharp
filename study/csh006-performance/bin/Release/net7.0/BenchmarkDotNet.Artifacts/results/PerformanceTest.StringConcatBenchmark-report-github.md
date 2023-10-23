```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|              Method |      Mean |     Error |    StdDev |    Median |     Gen0 |   Gen1 |  Allocated |
|-------------------- |----------:|----------:|----------:|----------:|---------:|-------:|-----------:|
| StringBuilderConcat |  33.17 μs |  0.816 μs |  2.354 μs |  33.23 μs |  42.9688 | 5.3711 |  175.72 KB |
|   GenericListConcat |  27.36 μs |  0.546 μs |  1.400 μs |  27.18 μs |  24.5972 |      - |  100.53 KB |
|       SimpletConcat | 205.77 μs | 11.311 μs | 30.964 μs | 195.64 μs | 688.4766 |      - | 2812.09 KB |
