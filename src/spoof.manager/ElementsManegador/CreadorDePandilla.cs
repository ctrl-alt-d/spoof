namespace spoof.manager.ElementsManegador;
using spoof.algoritmes;
using spoof.manager.ElementsDelJoc;
using spoof.abstrats;

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