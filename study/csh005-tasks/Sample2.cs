using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample2
{
    private static int[] _numbers = Enumerable.Range(0, 1000000).ToArray();

    public static void Execute()
    {
        Task<long> task = Task.Run(() =>
        {
            var total = Calculate();

            Task.Delay(10000).Wait();

            return total;
        });

        Console.WriteLine("Doing some other work...");

        long result = task.Result;

        Console.WriteLine($"Sum is {result}");
    }

    public static async void ExecuteAsync()
    {
        Task<long> task = Task.Run(() =>
        {
            var total = Calculate();

            Task.Delay(10000).Wait();

            return total;
        });

        Console.WriteLine("Doing some other work...");

        long result = await task;

        Console.WriteLine($"Sum is {result}");     
    }

    private static long Calculate()
    {
        long total = 0;
        for (int i = 0; i < _numbers.Length; i++)
        {
            total += _numbers[i];
        }

        return total;  
    }
}
