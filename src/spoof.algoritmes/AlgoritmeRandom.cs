using spoof.abstrats;

namespace spoof.algoritmes;

public class AlgoritmeRandom : IAlgoritmeSpoof
{
    private static readonly Random getrandom = new Random();

    public Pronostic FesPronostic(IPandilla pandilla)
        =>
        new(
            enPorto: 
                // Cada jugador pot portar entre 0 i 3 monedes
                getrandom
                .Next(0, 3),
            crecQueEnTotalHiHaura:
                // Pronòstic del total monedes que portarem entre tots
                getrandom
                .Next(0, pandilla.Count() * 3)            
        );

    public string GetNom()
        =>
        "Algoritme Random";

    public void SetIdJugador(string idJugador)
        =>
        Console
        .WriteLine($"Tinc el Id {idJugador}");

    public void SetResultatPartida(IPandilla pandilla)
        =>
        Console
        .WriteLine("S'ha acabat la partida. M'apunto com ha anat.");

}