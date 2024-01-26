public struct PathScores
{
    public int GScore;
    public int FScore;
    public int HScore;
    public PathScores(int g, int f, int h)
    {
        GScore = g;
        FScore = f;
        HScore = h;
    }

    
}