namespace spoof.manager.ElementsManegador;

using spoof.manager.ElementsDelJoc;
public class ExecutorDeJugades
{
    public void FesJugar(Pandilla pandilla)
    {
        DonarIdAlsJugador(pandilla);
    }

    private void DonarIdAlsJugador(Pandilla pandilla)
        =>
        pandilla
        .Cast<Jugador>()
        .ToList()
        .ForEach(jugador => jugador.AlgoritmeSpoof.SetIdJugador(Guid.NewGuid().ToString()));
}
