namespace spoof.manager.ElementsManegador;
using spoof.abstrats;

public class ElementsManegador
{
    private readonly ProporcionadorDalgoritmes _ProporcionadorDalgoritmes;
    private readonly CreadorDePandilla _CreadorDePandilla;
    private readonly ExecutorDeJugades _ExecutorDeJugades;

    public ElementsManegador(ProporcionadorDalgoritmes proporcionadorDalgoritmes, CreadorDePandilla creadorDePandilla, ExecutorDeJugades executorDeJugades)
    {
        _ProporcionadorDalgoritmes = proporcionadorDalgoritmes;
        _CreadorDePandilla = creadorDePandilla;
        _ExecutorDeJugades = executorDeJugades;
    }

    public IPandilla ExecutaElsAlgoritmes()
    {
        var algoritmes = _ProporcionadorDalgoritmes.DonamAlgoritmes();
        var pandilla = _CreadorDePandilla.CreaPandilla(algoritmes);
        _ExecutorDeJugades.FesJugar(pandilla, 10);
        return pandilla;
    }

    
}