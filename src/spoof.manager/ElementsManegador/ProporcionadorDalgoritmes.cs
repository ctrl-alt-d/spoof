namespace Spoof.Manager.ElementsManegador;
using Spoof.Algoritmes;
using Spoof.Abstrats;
public class ProporcionadorDalgoritmes
{
    public IEnumerable<IAlgoritmeSpoof> DonamAlgoritmes()
        =>
        new IAlgoritmeSpoof[] {
            new AlgoritmeZero(),
            new AlgoritmeUnaNeurona(),
            new AlgoritmeRandom(), // ToDo: Mirar dis l'assemblit tots els que implementin IAlgoritmeSpoof
        };
}