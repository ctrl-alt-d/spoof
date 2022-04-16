namespace spoof.manager.ElementsDelJoc;

using System.Collections;
using System.Linq;
using spoof.abstrats;

public class Pandilla : IPandilla
{
    private List<Jugador> _Jugadors = new();

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
        _Jugadors.Add(jugador);

    internal void TornPassaAlSeguent()
        =>
        Torn = (Torn + 1) % _Jugadors.Count;

    public IEnumerator<IJugador> GetEnumerator()
        =>
        this
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        =>
        Array.Empty<Jugador>()
        .Concat(_Jugadors.Skip(Torn))
        .Concat(_Jugadors.Take(Torn - 1))
        .GetEnumerator();
}
