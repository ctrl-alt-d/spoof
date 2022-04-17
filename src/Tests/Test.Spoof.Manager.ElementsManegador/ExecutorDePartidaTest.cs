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
        var jugador1 = new Mock<Jugador>(algoritmeSpoof).Object;
        var jugador2 = new Mock<Jugador>(algoritmeSpoof).Object;
        var pandilla = new Pandilla( new [] {jugador1, jugador2} );

        var policia = Mock.Of<PoliciaDeTrols>();
        var executorPartida = new ExecutorDePartida( policia );

        // -- When
        executorPartida.FesJugar(pandilla);

        // -- Assert
        
    }
}