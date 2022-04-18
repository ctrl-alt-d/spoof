namespace Spoof.Manager.ElementsManegador;
using Spoof.Abstrats;

public class Manegador
{
    private readonly ProporcionadorDalgoritmes _ProporcionadorDalgoritmes;
    private readonly CreadorDePandilla _CreadorDePandilla;
    private readonly ExecutorDeJugades _ExecutorDeJugades;

    public Manegador(ProporcionadorDalgoritmes proporcionadorDalgoritmes, CreadorDePandilla creadorDePandilla, ExecutorDeJugades executorDeJugades)
    {
        _ProporcionadorDalgoritmes = proporcionadorDalgoritmes;
        _CreadorDePandilla = creadorDePandilla;
        _ExecutorDeJugades = executorDeJugades;
    }

    public IPandilla ExecutaElsAlgoritmes()
    {
        var algoritmes = _ProporcionadorDalgoritmes.DonamAlgoritmes();
        var pandilla = _CreadorDePandilla.CreaPandilla(algoritmes);
        _ExecutorDeJugades.FesJugar(pandilla, 1000);
        return pandilla;
    }

    
}