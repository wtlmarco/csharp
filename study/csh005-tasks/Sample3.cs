using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample3
{
    public static void Execute()
    {
        Task task = Task.Factory.StartNew(() =>
        {
            // This code will run in a separate thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Iteration {i}");
                Thread.Sleep(1000);
            }
        });
    }
}
