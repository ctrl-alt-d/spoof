namespace Spoof.Manager.DI;

using Spoof.Manager.ElementsManegador;
using Microsoft.Extensions.DependencyInjection;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddSpoofManager(this IServiceCollection iserviceCollection)
        =>
        iserviceCollection
        .AddScoped<CreadorDePandilla>()
        .AddScoped<ExecutorDeJugades>()
        .AddScoped<ExecutorDePartida>()
        .AddScoped<Manegador>()
        .AddScoped<PoliciaDeTrols>()
        .AddScoped<ProporcionadorDalgoritmes>()
        ;

}