namespace spoof.manager.ElementsDelJoc;

using spoof.abstrats;

public class Jugador : IJugador
{
    public Jugador(IAlgoritmeSpoof algoritmeSpoof)
    {
        AlgoritmeSpoof = algoritmeSpoof;
    }
    public string IdJugador = Guid.NewGuid().ToString();
    public int? EnPronostica 
        =>
        Pronostic?.CrecQueEnTotalHiHaura;
    public bool PotMostrarLaMa {get; set;}
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
