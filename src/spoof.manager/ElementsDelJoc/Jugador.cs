namespace Spoof.Manager.ElementsDelJoc;

using Spoof.Abstrats;

public class Jugador : IJugador
{
    public Jugador(IAlgoritmeSpoof algoritmeSpoof)
    {
        AlgoritmeSpoof = algoritmeSpoof;
    }
    public void NetejaDades()
    {
        PotMostrarLaMa = false;
        GuanyaLaRonda = false;
        EnPorto = null;
        CrecQueEnTotalHiHaura = null;
    }
    public void PosaMonedesAlaMa()
        =>
        EnPorto = AlgoritmeSpoof.PosaMonedesAlaMa();
    internal int? EnPorto {get; private set;}
    public int? CrecQueEnTotalHiHaura {get; private set;}    
    public void FesPronostic(Pandilla pandilla)
        =>
        CrecQueEnTotalHiHaura = AlgoritmeSpoof.FesPronostic(pandilla);
    public string IdJugador = Guid.NewGuid().ToString();
    public bool PotMostrarLaMa {get; set;}
    public int? GetEnPorto() 
        =>
        PotMostrarLaMa ?
        EnPorto :
        null;
    public int PartidesGuanyades { get; internal set; }
    internal IAlgoritmeSpoof AlgoritmeSpoof { get; }
    public bool? GuanyaLaRonda {get; set; }
}
