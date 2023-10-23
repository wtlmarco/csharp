using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample6
{
    public static void ExecuteStart()
    {
        var task = new Task(async () =>
        {
            Console.WriteLine("Task running");
            
            await Task.Delay(10000);

            Console.WriteLine("Task complete");

        });

        Console.WriteLine("Execute running");

        Console.WriteLine("Task start!");
        
        task.Start();

        Console.WriteLine("Execute complete");
    }

    public static async void ExecuteSynchronously()
    {
        var task = new Task(() =>
        {
            Console.WriteLine("Task running");

            Task.Delay(10000).Wait();

            Console.WriteLine("Task complete");

        });

        Console.WriteLine("Execute running");

        Console.WriteLine("Task start!");
        
        task.Start();
        await task;

        Console.WriteLine("Execute complete");
    }
}
