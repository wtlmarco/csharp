```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
|           Method |      Mean |     Error |    StdDev | Allocated |
|----------------- |----------:|----------:|----------:|----------:|
|       MethodCall | 0.6160 ns | 0.0415 ns | 0.0919 ns |         - |
| MethodCallSealed | 0.0795 ns | 0.0317 ns | 0.0580 ns |         - |
