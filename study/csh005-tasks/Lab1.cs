using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskSampleApp;

class Nota
{
    public int ID;
    public double ValorTotal;
    public List<Item> Itens;

    public Nota()
    {
        Itens = new List<Item>();   
    }
}

class Item
{
    public int ID;
    public double Valor;
}

internal class Lab1
{
    private List<Nota> _notas;

    public Lab1()
    {
        _notas = new List<Nota>();
    }

    public void Load(int qtde = 50, bool random = false)
    {
        Random rnd = new Random();

        int qtdeNotas = 0;
        if (random)
            qtdeNotas = rnd.Next(1, qtde);
        else
            qtdeNotas = qtde;

        for (int a = 0; a < qtdeNotas; a++)
        {
            Nota nota = new() { ID = a+1};

            int qtdeItens = 0;
            if (random)
                qtdeItens = rnd.Next(1, qtde);
            else
                qtdeItens = qtde;
           
            for (int b = 0; b < qtdeItens; b++)
            {
                double valorItem = 0;

                if (random)
                    valorItem = rnd.NextDouble() * (1000.00 - 10.00) + 10.00;
                else
                    valorItem = 1;

                Item item = new() { ID = b+1, Valor = valorItem };
                nota.Itens.Add(item);
            }

            _notas.Add(nota);
        }
    }

    public void RunSync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        Task[] tasks = new Task[_notas.Count];

        double total = 0;
        for (var i = 0; i < _notas.Count; i++)
            total += Process(i, _notas[i]);

        stopwatch.Stop();
        
        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento síncrono concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public void RunAsyncTaskLock()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        Task[] tasks = new Task[_notas.Count];

        for (var i = 0; i < _notas.Count; i++)
        {
            int taskNum = i;
            tasks[taskNum] = new Task(() => { Process(taskNum, _notas[taskNum]); });
        }

        foreach (var task in tasks)
            task.Start();

        Task.WaitAll(tasks);

        double total = 0;
        foreach (var n in _notas)
            total += n.ValorTotal;

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public void RunAsyncTaskUnlock()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        Task[] tasks = new Task[_notas.Count];

        for (var i = 0; i < _notas.Count; i++)
        {
            int taskNum = i;
            tasks[taskNum] = new Task(async () => await ProcessAsync(taskNum, _notas[taskNum]));
        }

        foreach (var task in tasks)
            task.Start();

        Task.WaitAll(tasks);
        
        double total = 0;
        foreach (var n in _notas)
            total += n.ValorTotal;

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public void RunAsyncTaskLockUsingRefParameter()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        Task[] tasks = new Task[_notas.Count];

        double total = 0;
        for (var i = 0; i < _notas.Count; i++)
        {
            int taskNum = i;
            tasks[taskNum] = new Task(() => ProcessByRef(taskNum, _notas[taskNum], ref total));
        }

        foreach (var task in tasks)
            task.Start();

        Task.WaitAll(tasks);

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public void RunAsyncTaskParallelLock()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        double total = 0;
        Parallel.For(0, _notas.Count, i =>
        {
            ProcessByRef(i, _notas[i], ref total);
        });

        foreach (var n in _notas)
            total += n.ValorTotal;

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public void RunAsyncTaskParallelUnlock()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");
        
        Parallel.For(0, _notas.Count, async i =>
        {
            await ProcessAsync(i, _notas[i]);
        });

        double total = 0;
        foreach (var n in _notas)
            total += n.ValorTotal;

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    public async void RunAsyncTaskUnlockCompletion()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine($"Processando {_notas.Count} notas");

        TaskCompletionSource<double> tcs = new TaskCompletionSource<double>();

        Task.Factory.StartNew(() => 
        {
            for (int i = 0; i < _notas.Count; i++)
                Process(i, _notas[i]);

            double total = 0;
            foreach (var n in _notas) 
                total += n.ValorTotal;

            tcs.SetResult(total);
        });

        var total = await tcs.Task;

        stopwatch.Stop();

        Console.WriteLine($"Total Faturado R${total:0.##}");

        Console.WriteLine($"Processamento concluído em {stopwatch.ElapsedMilliseconds} ms!");
    }

    private double Process(int i, Nota n)
    {
        foreach (var item in n.Itens)
            n.ValorTotal += item.Valor;

        Task.Delay(1000).Wait();

        Console.WriteLine($"Task {i}: Nota {n.ID} processada, Valor Total: R$ {n.ValorTotal:0.##}");

        return n.ValorTotal;
    }

    private async Task<double> ProcessAsync(int i, Nota n)
    {
        double valorTotal = 0;
        foreach (var item in n.Itens)
            valorTotal += item.Valor;

        n.ValorTotal = valorTotal;

        await Task.Delay(1000); //Simula carga

        Console.WriteLine($"Task {i}: Nota {n.ID} processada, Valor Total: R$ {n.ValorTotal:0.##}");

        return valorTotal;
    }

    public void ProcessByRef(int i, Nota n, ref double total)
    {
        foreach (var item in n.Itens)
            n.ValorTotal += item.Valor;

        total += n.ValorTotal;

        Task.Delay(1000).Wait(); //Simula carga

        Console.WriteLine($"Task {i}: Nota {n.ID} processada, Valor Total: R$ {n.ValorTotal:0.##}");
    }
}
