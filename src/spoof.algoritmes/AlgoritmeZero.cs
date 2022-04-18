using Spoof.Abstrats;

namespace Spoof.Algoritmes;

public class AlgoritmeZero : IAlgoritmeSpoof
{
    private static readonly Random getrandom = new Random();

    public int FesPronostic(IPandilla pandilla)
        =>
        Enumerable
        // Podem triar entre 0 i jugadors x 3:
        .Range(0, pandilla.Count() * 3)  
        // No podem triar els que ja estiguin triats:
        .Where(i => !pandilla.Select(j => j.CrecQueEnTotalHiHaura).Contains(i))
        // Ordeno i en pillo el primer:
        .OrderBy(a => a)
        .First();

    public string GetNom()
        =>
        "Algoritme Zero";

    public int PosaMonedesAlaMa()
        =>
        0;

    public void SetEstasExpulsat(string motiu)
        =>
        Console
        .WriteLine($"M'han expulsat {motiu}");

    public void SetIdJugador(string idJugador)
        =>
        //Console
        //.WriteLine($"Tinc el Id {idJugador}");
        _ = 1;
    public void SetResultatPartida(IPandilla pandilla)
        =>
        // Console
        // .WriteLine("S'ha acabat la partida. M'apunto com ha anat.");
        _ = 1;

}