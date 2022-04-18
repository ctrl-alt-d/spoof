using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spoof.Manager.DI;


await
    Host
    .CreateDefaultBuilder(args)
    .ConfigureServices(
        (_, services) =>
        services
        .AddHostedService<Spoof.Exe.Console.App>()
        .AddSpoofManager())
    .Build()
    .RunAsync();
