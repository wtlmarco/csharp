using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample1
{
    public static void Execute()
    {
        Console.WriteLine("Start execute!");

        Task.Run(() =>
        {
            Task.Delay(5000).Wait();
            Console.WriteLine("Running in separate thread!");
        });

        Console.WriteLine("Execute finished!");
    }
}
