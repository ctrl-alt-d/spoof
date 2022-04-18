using Xunit;
using Spoof.Manager.ElementsDelJoc;
using Moq;
using Spoof.Abstrats;
using System.Linq;
using FluentAssertions;

namespace Test.Spoof.Manager.ElementsDelJoc;

public class EsPotIterarPelsJugadorsDelIPandilla
{
    [Fact]
    public void Test1()
    {
        // -- Giving
        var algoritmeSpoof = Mock.Of<IAlgoritmeSpoof>();
        var jugador1 = new Mock<Jugador>(algoritmeSpoof).Object;
        var jugador2 = new Mock<Jugador>(algoritmeSpoof).Object;
        var jugador3 = new Mock<Jugador>(algoritmeSpoof).Object;
        var pandilla = new Pandilla( new [] {jugador1, jugador2, jugador3} );

        // -- When
        var n0 = pandilla.Count();
        var j0 = pandilla.First();
        pandilla.TornPassaAlSeguent();

        var n1 = pandilla.Count();
        var j1 = pandilla.First();
        pandilla.TornPassaAlSeguent();

        var n2 = pandilla.Count();
        var j2 = pandilla.First();
        pandilla.TornPassaAlSeguent();

        var n3 = pandilla.Count();
        var j3 = pandilla.First();
        
        // -- Assert
        n0.Should().Be(3);
        n1.Should().Be(3);
        n2.Should().Be(3);
        n3.Should().Be(3);

        j0.Should().Be(jugador1);
        j1.Should().Be(jugador2);
        j2.Should().Be(jugador3);
        j3.Should().Be(jugador1);
    }
}