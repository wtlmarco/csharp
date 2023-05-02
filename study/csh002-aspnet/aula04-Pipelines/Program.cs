using System;
using System.Text;

using aula04.Simples;
using aula04.Duplo;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Pipeline Simples para Monagem de Veículos");

        Pipeline<StringBuilder> montagemVeiculo = new Pipeline<StringBuilder>();
        montagemVeiculo.AdicionarEtapa(new EtapaChassi());
        montagemVeiculo.AdicionarEtapa(new EtapaMotor());
        montagemVeiculo.AdicionarEtapa(new EtapaBancos());
        montagemVeiculo.AdicionarEtapa(new EtapaCarroceria());
        montagemVeiculo.AdicionarEtapa(new EtapaPortas());
        montagemVeiculo.AdicionarEtapa(new EtapaPintura());

        for (int i = 0; i < 10; i++)
        {
            var veiculo = montagemVeiculo.Processar(new StringBuilder());
            Console.WriteLine($"Veículo {i + 1:D2} {veiculo.ToString()}");    
        }

        Console.WriteLine("Pipeline Duplo para Monagem de Veículos");

        PipelineDuplo<StringBuilder> montagemVeiculo2 = new PipelineDuplo<StringBuilder>();
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploChassi());
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploMotor());
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploBancos());
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploCarroceria());
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploPortas());
        montagemVeiculo2.AdicionarEtapa(new EtapaDuploPintura());

        for (int i = 0; i < 10; i++)
        {
            var veiculo = montagemVeiculo2.Processar(new StringBuilder());
            Console.WriteLine($"Veículo {i + 1:D2} {veiculo.ToString()}");    
        }
    }
}