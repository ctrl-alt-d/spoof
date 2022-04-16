namespace spoof.manager.ElementsDelJoc;

using spoof.abstrats;

public class Jugador : IJugador
{
    public Jugador(IAlgoritmeSpoof algoritmeSpoof)
    {
        AlgoritmeSpoof = algoritmeSpoof;
    }
    public int? EnPronostica 
        =>
        Pronostic?.CrecQueEnTotalHiHaura;
    private bool PotMostrarLaMa {get; set;}
    public int? EnPortava 
        =>
        PotMostrarLaMa ?
        Pronostic?.EnPorto :
        null;
    public int PartidesGuanyades { get; internal set; }
    internal IAlgoritmeSpoof AlgoritmeSpoof { get; }
    internal Pronostic? Pronostic { get; set; }
    public bool? GuanyaLaRonda {get; set; }
}
