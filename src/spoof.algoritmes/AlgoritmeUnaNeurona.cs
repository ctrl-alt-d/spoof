using Spoof.Abstrats;

namespace Spoof.Algoritmes;

public class AlgoritmeUnaNeurona : IAlgoritmeSpoof
{
    private static readonly Random getrandom = new Random();

    int? MonedesAlaMa;
    public int FesPronostic(IPandilla pandilla)
    {
        var num_de_contraris = pandilla.Count() - 1;

        var altres_pronostics = 
            pandilla
            .Select(p=>p.CrecQueEnTotalHiHaura)
            .Where(c => c != null);

        while (true){

            var pronostic = 
                Enumerable
                // Podem triar entre 0 i jugadors x 3:
                .Range(0, pandilla.Count() - 1)  
                // No podem triar els que ja estiguin triats:
                .Sum(i => getrandom.Next(0, 3))
                + MonedesAlaMa!.Value;

            if (!altres_pronostics.Contains(pronostic))
                return pronostic;
        };
            
    }
    public string GetNom()
        =>
        "Algoritme amb una Neurona";

    public int PosaMonedesAlaMa()
    {
        MonedesAlaMa =
            getrandom
            .Next(0, 3);
        return MonedesAlaMa!.Value;
    }
        
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