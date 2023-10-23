using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample8
{
    public static void RunSimple()
    {
        var task1 = new Task(async () => 
        { 
            await Task.Delay(1000);

            Console.WriteLine("Task 1 finished!");
        });

        var task2 = new Task(async () => 
        {
            await Task.Delay(2000);

            Console.WriteLine("Task 2 finished!");
        });

        task1.Start();
        task2.Start();

        var t = Task.WhenAll(task1, task2);
        
        //task1.Wait();
        //task2.Wait();

        Console.WriteLine("Tasks completed!");
        t.Wait();
    }
}

