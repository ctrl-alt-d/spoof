using Xunit;
using Spoof.Manager.ElementsDelJoc;
using Spoof.Manager.ElementsManegador;
using Moq;
using Spoof.Abstrats;
using System.Linq;
using FluentAssertions;

namespace Test.Spoof.Manager.ElementsManegador;

public class ExecutorDePartidaTest
{
    [Fact]
    public void ExecutorSapDetectarElGuanyador()
    {
        // -- Giving
        var algoritmeSpoof = Mock.Of<IAlgoritmeSpoof>();
        var jugador1Mock = new Mock<Jugador>(algoritmeSpoof);
        var jugador2Mock = new Mock<Jugador>(algoritmeSpoof);
        var jugadors = new [] {jugador1Mock.Object, jugador2Mock.Object};
        var pandilla = new Pandilla( jugadors );
        var policia = Mock.Of<PoliciaDeTrols>();
        var executorPartida = new ExecutorDePartida( policia );

        // Fem que el jugador 1 encerti
        jugador1Mock.Setup(j => j.GetEnPorto()).Returns(3);
        jugador1Mock.Setup(j => j.CrecQueEnTotalHiHaura).Returns(3);
        
        // Fem que el jugador 2 falli
        jugador2Mock.Setup(j => j.GetEnPorto()).Returns(0);
        jugador2Mock.Setup(j => j.CrecQueEnTotalHiHaura).Returns(1000);
        
        // -- When juguen dues partides
        executorPartida.FesJugar(pandilla);
        executorPartida.FesJugar(pandilla);

        // -- Assert
        jugador1Mock.Object.GuanyaLaRonda.Should().BeTrue();
        jugador2Mock.Object.GuanyaLaRonda.Should().BeFalse();
        
        jugador1Mock.Object.PartidesGuanyades.Should().Be(2);
        jugador2Mock.Object.PartidesGuanyades.Should().Be(0);
        
    }
}