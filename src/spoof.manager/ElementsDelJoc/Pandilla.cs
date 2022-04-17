namespace spoof.manager.ElementsDelJoc;

using System.Collections;
using System.Linq;
using spoof.abstrats;

public class Pandilla : IPandilla
{
    public List<Jugador> Jugadors = new();

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

    internal void TornPassaAlSeguent()
        =>
        Torn = (Torn + 1) % Jugadors.Count;

    public IEnumerator<IJugador> GetEnumerator()
        =>
        this
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        GetJugadorsPerOrdreDeTorn()
        .GetEnumerator();
    
    internal IEnumerable<Jugador> GetJugadorsPerOrdreDeTorn()
        =>
        Array.Empty<Jugador>()
        .Concat(Jugadors.Skip(Torn))
        .Concat(Jugadors.Take(Torn - 1));

}
