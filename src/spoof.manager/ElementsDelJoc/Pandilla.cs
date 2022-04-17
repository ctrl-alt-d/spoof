namespace Spoof.Manager.ElementsDelJoc;

using System.Collections;
using System.Linq;
using Spoof.Abstrats;

public class Pandilla : IPandilla
{
    public List<Jugador> Jugadors {get; }= new();

    public Pandilla(IEnumerable<Jugador> jugadors)
        =>
        jugadors
        .ToList()
        .ForEach( jugador =>
            AfegirJugador(jugador)
        );

    public int PartidesJugades {get; internal set;}

    internal int Torn {  get;  set; } = 0;

    internal void AfegirJugador(Jugador jugador)
        =>
        Jugadors.Add(jugador);

    public void TornPassaAlSeguent()
        =>
        Torn = (Torn + 1) % Jugadors.Count;
    
    internal IEnumerable<Jugador> GetJugadorsPerOrdreDeTorn()
        =>
        Array.Empty<Jugador>()
        .Concat(Jugadors.Skip(Torn))
        .Concat(Jugadors.Take(Torn));

    public IEnumerator<IJugador> GetEnumerator()
        =>
        GetJugadorsPerOrdreDeTorn()
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        GetEnumerator();
}
