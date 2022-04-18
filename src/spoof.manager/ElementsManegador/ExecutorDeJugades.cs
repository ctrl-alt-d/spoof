namespace Spoof.Manager.ElementsManegador;

using Spoof.Manager.ElementsDelJoc;
public class ExecutorDeJugades
{
    private readonly ExecutorDePartida _ExecutorDePartida;

    public ExecutorDeJugades(ExecutorDePartida executorDePartida)
    {
        _ExecutorDePartida = executorDePartida;
    }

    public void FesJugar(Pandilla pandilla, int num_partides)
    {
        DonarIdAlsJugador(pandilla);    
        Enumerable
            .Range(0,num_partides)
            .Select(_ => pandilla)
            .ToList()
            .ForEach( _ExecutorDePartida.FesJugar );
    }
    private void DonarIdAlsJugador(Pandilla pandilla)
        =>
        pandilla
        .Jugadors
        .ForEach(
            DonarIdAlJugador
        );

    private static void DonarIdAlJugador(Jugador jugador)
        =>
        jugador
        .AlgoritmeSpoof
        .SetIdJugador(jugador.IdJugador);

}
