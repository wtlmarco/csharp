using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample5
{
    public static async void ExecuteAsync()
    {
        await Task.Run(async () =>
        {
            await Task.Delay(10000);

            Console.WriteLine("Done with the async task!");
        });

        Console.WriteLine("Task complete and continue the others actions!");
    }

    public static void Execute()
    {
        Task.Run(() =>
        {
            Task.Delay(10000);

            Console.WriteLine("Done task!");
        });

        Console.WriteLine("Task complete and continue the others actions!");
    }
}
