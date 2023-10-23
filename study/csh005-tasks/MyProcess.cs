using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TaskSampleApp;

public class MyProcess
{
    private int _time;

    public MyProcess(int time)
    {
        _time = time;
    }

    public async Task RunASync()
    {
        Console.WriteLine($"Process {_time} sec start");
        await Task.Delay(_time * 1000);
        Console.WriteLine($"Process {_time} sec finish");
    }

    public void Run()
    {
        Console.WriteLine($"Process {_time} sec start");
        Task.Delay(_time * 1000);
        Console.WriteLine($"Process {_time} sec finish");
    }
}
