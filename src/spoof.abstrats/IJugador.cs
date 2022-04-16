namespace spoof.abstrats;

public interface IJugador
{
    int? EnPronostica { get; }
    int? EnPortava { get; }
    int PartidesGuanyades { get; }
    bool? GuanyaLaRonda {get; }
}
