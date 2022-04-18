using Spoof.Manager.ElementsDelJoc;

namespace Spoof.Manager.ElementsManegador;

public class PoliciaDeTrols
{
    const string NUMEROMONEDESALPUNYMALAMENT = "Només es poden tenir entre 0 i 3 monedes a la mà";
    const string REPETITPRONOSTIC = "Has repetit pronòstic";
    public void VigilaElsTrolsMonedesAlPuny(Pandilla pandilla)
    {
        var trols = DetectarTrolsMonedesAlaMa(pandilla);
        NotificaTrols(trols, NUMEROMONEDESALPUNYMALAMENT);
        EliminarElsTrols(pandilla, trols);
    }
    public void VigilaElsTrolsPronosticRepetit(Pandilla pandilla)
    {
        var trols = DetectarTrolsPronosticRepetit(pandilla);
        NotificaTrols(trols, REPETITPRONOSTIC);
        EliminarElsTrols(pandilla, trols);
    }
    public static IEnumerable<Jugador> DetectarTrolsMonedesAlaMa(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .Where(JugadorFaElTrollMonedesAlaMa);

    public static IEnumerable<Jugador> DetectarTrolsPronosticRepetit(Pandilla pandilla)
        =>
        pandilla
        .GetJugadorsPerOrdreDeTorn()
        .Where(jugador=>jugador.CrecQueEnTotalHiHaura != null)
        .Where((jugador, idx) => 
            pronostic_repetit(pandilla, jugador.CrecQueEnTotalHiHaura!.Value, idx)
        );

    private static bool pronostic_repetit(Pandilla pandilla, int crecQueEnTotalHiHaura, int idx)
        =>
        pandilla
        .GetJugadorsPerOrdreDeTorn()
        .Take(idx)
        .Select(j=>j.CrecQueEnTotalHiHaura)
        .Contains(crecQueEnTotalHiHaura);

    public static bool JugadorFaElTrollMonedesAlaMa(Jugador jugador)
        =>
        jugador.EnPorto > 3 ||
        jugador.EnPorto < 0;

    public static void NotificaTrols(IEnumerable<Jugador> trols, string msg)
        =>
        trols
        .ToList()
        .ForEach(trol => trol.AlgoritmeSpoof.SetEstasExpulsat(msg));

    public static void EliminarElsTrols(Pandilla pandilla, IEnumerable<Jugador> trols)
        =>
        trols
        .ToList()
        .ForEach(trol => pandilla.Jugadors.Remove(trol));

}
