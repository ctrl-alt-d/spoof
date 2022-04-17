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
        var pandilla = new Pandilla( new [] {jugador1, jugador2} );

        // -- When
        var n = pandilla.Count();

        // -- Assert
        n.Should().Be(2);
    }
}