using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSampleApp;

internal static class Sample4
{
    public static async void Execute()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        Task longRunningTask = Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }

                Console.WriteLine($"Iteration {i}");
                Thread.Sleep(1000);
            }
        }, cancellationTokenSource.Token);

        await Task.Delay(5000);

        cancellationTokenSource.Cancel();

        Console.WriteLine($"Task cancelled");
    }
}
