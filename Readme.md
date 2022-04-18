# Spoof

Spoof és una app 100% c# que fa jugar diferents [algorismes](./src/Spoof.Algoritmes) al joc dels ["Chinos"](https://es.wikipedia.org/wiki/Chinos_(juego)). Cal [registrar a mà](./src/Spoof.Manager/ElementsManegador/ProporcionadorDalgoritmes.cs) els algoritmes (per si en vols crear de nous)

El programa s'inicia executant [Sppof.Exe.Console](./src/Spoof.Exe.Console):

```
% dotnet run --project src/Spoof.Exe.Console 
Partides Jugades: 1000
Total Jugadors: 3
Algoritme amb una Neurona guanya 238 partides
Algoritme Random guanya 220 partides
Algoritme Zero guanya 119 partides
```

Aquest programa és només un assaig per treballar amb conceptes com [IoC](https://docs.microsoft.com/en-us/windows/communitytoolkit/mvvm/ioc), [DI](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0) i [Testing](./src/Tests).

Un cop fet el programa veig que dona poc joc a la creativitat, el joc està massa bassat en l'atzar com per a fer algorismes amb estratègies. Havia pensat a 'prohibir' el random a l'algoritme, però el joc no dona per tant.

Per tal de poder treballar amb altres conceptes com ML o algoritmes genètics caldria buscar un joc menys bassat a l'atzar i més bassat en l'estratègia.