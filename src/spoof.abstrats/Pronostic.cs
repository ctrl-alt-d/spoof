namespace spoof.abstrats;
public record Pronostic
{
    public Pronostic(int enPorto, int crecQueEnTotalHiHaura)
    {
        EnPorto = enPorto;
        CrecQueEnTotalHiHaura = crecQueEnTotalHiHaura;
    }
    public int EnPorto {get;}
    public int CrecQueEnTotalHiHaura {get;}
}
