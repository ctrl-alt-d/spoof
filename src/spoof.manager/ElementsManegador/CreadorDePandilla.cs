namespace Spoof.Manager.ElementsManegador;
using Spoof.Algoritmes;
using Spoof.Manager.ElementsDelJoc;
using Spoof.Abstrats;

public class CreadorDePandilla
{
    public Pandilla CreaPandilla(IEnumerable<IAlgoritmeSpoof> algoritmes)
        =>
        new Pandilla(
            algoritmes
            .Select(algoritme =>
                new Jugador(algoritme)
            )
        );
}