namespace spoof.manager.ElementsManegador;

using spoof.manager.ElementsDelJoc;
public class ExecutorDePartida
{

    public void FesJugar(Pandilla pandilla)
    {
        MarcarIniciDePartida(pandilla);
        DemanarPronostic(pandilla);
        var trols = DetectarTrols(pandilla);
        EliminarElsTrols(pandilla, trols);
        var total_monedes = RecompteMonedes(pandilla);
        var guanyador = DeterminaGuanyador(pandilla, total_monedes);
        InformaGuanyador(pandilla, guanyador);
    }

    public void MarcarIniciDePartida(Pandilla pandilla)
        =>
        pandilla
            .Jugadors
            .ForEach(jugador => {
                jugador.PotMostrarLaMa = false;
                jugador.GuanyaLaRonda = false;
            });

    public void DemanarPronostic(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .ForEach(jugador => 
            jugador.Pronostic = jugador.AlgoritmeSpoof.FesPronostic(pandilla)
        );

    public IEnumerable<Jugador> DetectarTrols(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .Where(JugadorFaElTroll);
    
    public bool JugadorFaElTroll(Jugador jugador)
        =>
        jugador.Pronostic.EnPorto > 3 ||
        jugador.Pronostic.EnPorto < 0;

    public void EliminarElsTrols(Pandilla pandilla, IEnumerable<Jugador> trols)
        =>
        trols
        .ToList()
        .ForEach(trol => pandilla.Jugadors.Remove(trol));

    public int RecompteMonedes(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .Sum(jugador => jugador.Pronostic.EnPorto);

    public Jugador? DeterminaGuanyador(Pandilla pandilla, int resposta_correcte)
        =>
        pandilla
        .Jugadors
        .FirstOrDefault(jugador=>jugador.Pronostic.EnPorto == resposta_correcte);

    public void InformaGuanyador(Pandilla pandilla, Jugador? guanyador)
    {
        // Sumar un punt al guanyador
        if (guanyador != null)
        {
            guanyador.PartidesGuanyades++;
            guanyador.GuanyaLaRonda=true;
        }

        // Ja poden obrir la ma
        // Marcar qui guanya la ronda
        pandilla
            .Jugadors
            .ForEach(jugador => {
                jugador.PotMostrarLaMa = true;
                jugador.GuanyaLaRonda = true;
            });

        // Avisar als algoritmes que la ronda ha acabat
        pandilla
            .Jugadors
            .ForEach(jugador => jugador.AlgoritmeSpoof.SetResultatPartida(pandilla));

    }

}
