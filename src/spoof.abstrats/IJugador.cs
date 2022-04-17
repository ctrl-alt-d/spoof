namespace Spoof.Abstrats;

public interface IJugador
{
    int? CrecQueEnTotalHiHaura { get; }
    int? GetEnPorto();
    int PartidesGuanyades { get; }
    bool? GuanyaLaRonda {get; }
}
