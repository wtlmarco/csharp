using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample7
{
    public static void RunSimple()
    {
        var timer = new Timer(state => 
        {
            Console.WriteLine("Running periodic task...");
        },null,TimeSpan.Zero,TimeSpan.FromSeconds(5));
    }

    public static void RunAsync()
    {
        var timer = new Timer(async (e) =>
        {
            Console.WriteLine("Checking the server´s health...");
            
            await Task.Delay(3000);

            Console.WriteLine("Server health check completed");
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
    }

    public static void RunJob()
    {
        var timer = new Timer(state =>
        {
            Task.Run(async () => await Process());
        }, null, TimeSpan.Zero, TimeSpan.FromHours(1));
    }

    private static async Task Process()
    {
        Console.WriteLine("Data processing started");

        await Task.Delay(TimeSpan.FromMinutes(10));
        
        Console.WriteLine("Data processing completed after 10 minutes");
    }
}

