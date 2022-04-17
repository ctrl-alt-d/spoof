using spoof.manager.ElementsDelJoc;

namespace spoof.manager.ElementsManegador;

public class PoliciaDeTrols
{
    public void VigilaElsTrols(Pandilla pandilla)
    {
        var trols = DetectarTrols(pandilla);
        NotificaTrols(trols);
        EliminarElsTrols(pandilla, trols);
    }
    public IEnumerable<Jugador> DetectarTrols(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .Where(JugadorFaElTroll);
    
    public bool JugadorFaElTroll(Jugador jugador)
        =>
        jugador.EnPorto > 3 ||
        jugador.EnPorto < 0;

    public void NotificaTrols(IEnumerable<Jugador> trols)
        =>
        trols
        .ToList()
        .ForEach(trol => trol.AlgoritmeSpoof.SetEstasExpulsat("Només es poden tenir entre 0 i 3 monedes a la mà"));

    public void EliminarElsTrols(Pandilla pandilla, IEnumerable<Jugador> trols)
        =>
        trols
        .ToList()
        .ForEach(trol => pandilla.Jugadors.Remove(trol));

}
