namespace Spoof.Manager.ElementsManegador;

using Spoof.Manager.ElementsDelJoc;
public class ExecutorDePartida
{
    private readonly PoliciaDeTrols _PoliciaDeTrols;

    public ExecutorDePartida(PoliciaDeTrols policiaDeTrols)
    {
        _PoliciaDeTrols = policiaDeTrols;
    }
    public void FesJugar(Pandilla pandilla)
    {
        // Jugadors es preparen
        MarcarIniciDePartida(pandilla);

        // Posen les monedes al puny tancat
        PosaMonedesAlesMans(pandilla);

        // Passa la poli per si algú fa el trol
        _PoliciaDeTrols.VigilaElsTrolsMonedesAlPuny(pandilla);

        // Demanem pronòstic
        DemanarPronostic(pandilla);

        // Torna a passar la poli per si algú fa el trol
        _PoliciaDeTrols.VigilaElsTrolsPronosticRepetit(pandilla);

        // Determinem el guanyador
        var total_monedes = RecompteMonedes(pandilla);
        var guanyador = DeterminaGuanyador(pandilla, total_monedes);

        // Sumem punt al guanyador i informem als jugadors del final de la ronda
        InformaGuanyador(pandilla, guanyador);
    }
    public void MarcarIniciDePartida(Pandilla pandilla)
        =>
        pandilla
            .Jugadors
            .ForEach(jugador => jugador.NetejaDades());
    public void DemanarPronostic(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .ForEach(jugador => 
            jugador.FesPronostic(pandilla)
        );
    public void PosaMonedesAlesMans(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .ForEach(jugador => 
            jugador.PosaMonedesAlaMa()
        );
    public int RecompteMonedes(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .Sum(jugador => jugador.EnPorto!.Value);
    public Jugador? DeterminaGuanyador(Pandilla pandilla, int resposta_correcte)
        =>
        pandilla
        .Jugadors
        .FirstOrDefault(jugador=>jugador.EnPorto == resposta_correcte);
    public void InformaGuanyador(Pandilla pandilla, Jugador? guanyador)
    {
        // Sumar un punt al guanyador
        if (guanyador != null)
        {
            guanyador.PartidesGuanyades++;
            guanyador.GuanyaLaRonda=true;
        }

        // Hem jugat una altra partida
        pandilla.PartidesJugades++;

        // Ja poden obrir el puny
        pandilla
            .Jugadors
            .ForEach(jugador => {
                jugador.PotMostrarLaMa = true;
            });

        // Avisar als algoritmes que la ronda ha acabat
        pandilla
            .Jugadors
            .ForEach(jugador => jugador.AlgoritmeSpoof.SetResultatPartida(pandilla));

        // Comença el següent
        pandilla.TornPassaAlSeguent();

    }

}
