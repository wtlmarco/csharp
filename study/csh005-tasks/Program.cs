// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;

using TaskSampleApp;

Console.WriteLine($"-------------------------");
Console.WriteLine($"Tasks study...");
Console.WriteLine($"-------------------------");

//MyProcess p1 = new MyProcess(5);
//MyProcess p2 = new MyProcess(10);
//MyProcess p3 = new MyProcess(3);

//Task p1Task = p1.RunASync();
//Task p2Task = p2.RunASync();
//Task p3Task = p3.RunASync();
//await Task.Factory.ContinueWhenAll(new Task[] { p2Task, p1Task, p3Task }, p => { Console.WriteLine("**OI**"); });
//Console.WriteLine("**Intervalo**");

//await p1.RunASync();
//Console.WriteLine("**Intervalo**");
//await p2.RunASync();


//Digite livremente e perceba se a tela imprime normalmente
Console.WriteLine($"Write freely in the console...");

//1) Simples criação de Task que gera ação enquanto aplicação está livre para trabalhar
//Sample1.Execute();

//2) Diferença do await e do .Result
//Usando sem o await a aplicação fica indisponível até a conclusão do processamento
//ou seja a operação fica síncrona
//Sample2.Execute();

//Usando await podemos utilizar a aplicação enquanto aguardamos o processamento
//ou seja a operação fica assíncrona
//Sample2.ExecuteAsync();

//3) O Task Factory funciona com um Orquestrador das Tasks permitindo organizar as Tasks
//em Agendamento, Cancelamento e Relacionamentos

//Nesse exemplo podemos simultaneamente digitar na tela enquanto a Task imprime os dados
//Sample3.Execute();

//Nesse exemplo usamos o Factory para controlar um possível cancelamento da Task
//Sample4.Execute();

//4) Uso do async e await
//Nesse exemplo perceba que sem o uso do await a execução ocorre sem processar o Delay
//sendo que com o uso do await é indicado um ponto de espera para continuar o processamento
//da Task e a maneira assíncrona não trava a digitação
//Sample5.Execute();
//Sample5.ExecuteAsync();

//5) Controlar a inicialização da Task com o Start 
//Nesse exemplo a execução completa separadamente da Task
//Sample6.ExecuteStart();
//Nesse exemplo a execução fica na espera para completar somente na conclusão da Task
//Sample6.ExecuteSynchronously();

//6) Uso de Timer
//Sample7.RunSimple();
//Sample7.RunAsync();
//Sample7.RunJob();

//7) Encadeando as Task
Sample8.RunSimple();

//LAB1) Simulação de processamento assíncrono de Notas Fiscais
//Lab1 s = new Lab1();
//s.Load();
//s.RunSync(); //TEST A - Síncrona processando cada nota individualmente T=50s
//s.RunAsyncTaskLock(); //TEST B - Assíncrona com lock da Thread Principal e encadeamento dos Processamento com Resultado
//s.RunAsyncTaskUnlock(); //TEST C - Assíncrona sem lock da Thread Principal e sem encadeamento dos Processamento com Resultado
//s.RunAsyncTaskUnlockCompletion(); //TEST C.1 - Usando um sinalizador de finalização da task que libera a Thread principal e encadeia o Processamento com Resultado
//s.RunAsyncTaskLockUsingRefParameter(); //TEST B.1 - Adaptação usando varíavel por refêrencia para gerar Resultado durante o Processamento 
//s.RunAsyncTaskParallelLock(); //TEST B.2 - Adaptação utilizando a função de Paralelismo
//s.RunAsyncTaskParallelUnlock(); //TEST B.2.1 - Excelente Processamento com o Resultado encadeado


//Simula a Thread principal da tela do usuário que permite receber digitação
Console.ReadLine();