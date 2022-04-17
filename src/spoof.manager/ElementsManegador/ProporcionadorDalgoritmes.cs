namespace Spoof.Manager.ElementsManegador;
using Spoof.Algoritmes;
using Spoof.Abstrats;
public class ProporcionadorDalgoritmes
{
    public IEnumerable<IAlgoritmeSpoof> DonamAlgoritmes()
        =>
        new [] {
            new AlgoritmeRandom(), // ToDo: Mirar dis l'assemblit tots els que implementin IAlgoritmeSpoof
            new AlgoritmeRandom() // Li passo dos cops per a que lluitin entren ells
        };
}