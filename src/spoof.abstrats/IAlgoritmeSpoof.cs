namespace Spoof.Abstrats;
public interface IAlgoritmeSpoof
{
    string GetNom();
    void SetIdJugador(string idJugador);
    int PosaMonedesAlaMa();
    int FesPronostic(IPandilla pandilla);
    void SetResultatPartida(IPandilla pandilla);
    void SetEstasExpulsat(string motiu);
}
