namespace spoof.manager.ElementsManegador;
using spoof.algoritmes;
using spoof.abstrats;
public class ProporcionadorDalgoritmes
{
    public IEnumerable<IAlgoritmeSpoof> DonamAlgoritmes()
        =>
        new [] {
            new AlgoritmeRandom(), // ToDo: Mirar dis l'assemblit tots els que implementin IAlgoritmeSpoof
            new AlgoritmeRandom() // Li passo dos cops per a que lluitin entren ells
        };
}