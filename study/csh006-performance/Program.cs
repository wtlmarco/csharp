using System;

using BenchmarkDotNet.Running;

using PerformanceTest;

/*
 * Benchmark tests
 * 
 * Project: https://github.com/dotnet/BenchmarkDotNet
 * Documentation: https://benchmarkdotnet.org/articles/overview.html
 * Article: https://dev.to/newday-technology/measuring-performance-using-benchmarkdotnet-part-1-39g3
 */

Console.WriteLine("Benchmark Test ...");

//var summary = BenchmarkRunner.Run<PersonCallBenchmark>();

//var summary = BenchmarkRunner.Run<public class PersonCallArrayBenchmark>();

var summary = BenchmarkRunner.Run(typeof(StringConcatBenchmark));

//var summary = BenchmarkRunner.Run(typeof(FibonacciBenchmark));

//var summary = BenchmarkRunner.Run(typeof(SerializeObjectBenchmark));



