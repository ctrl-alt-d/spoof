namespace Spoof.Exe.Console;

using Spoof.Manager.ElementsManegador;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;

public class App : IHostedService
{
    public readonly Manegador _Manegador;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public App(Manegador manegador, IHostApplicationLifetime hostApplicationLifetime)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _Manegador = manegador;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var pandilla = _Manegador.ExecutaElsAlgoritmes();

        Console.WriteLine($"Partides Jugades: {pandilla.PartidesJugades}");

        pandilla
        .OrderByDescending(j => j.PartidesGuanyades)
        .ToList()
        .ForEach(j =>
            Console.WriteLine($"{j.GetNomAlgoritme()} guanya {j.PartidesGuanyades} partides")
        );

        _hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        =>
        Task.CompletedTask;

    public Task WaitForStartAsync(CancellationToken cancellationToken)
        =>
        Task.CompletedTask;

}