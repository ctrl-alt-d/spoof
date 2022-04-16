namespace spoof.abstrats;
public interface IAlgoritmeSpoof
{
    string GetNom();
    void SetIdJugador(string idJugador);
    Pronostic FesPronostic(IPandilla pandilla);
    void SetResultatPartida(IPandilla pandilla);
}
