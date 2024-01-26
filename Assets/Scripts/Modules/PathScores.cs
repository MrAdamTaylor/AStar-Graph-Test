public struct PathScores
{
    public float GScore;
    public float FScore;
    public float HScore;
    public PathScores(float g, float f, float h)
    {
        GScore = g;
        FScore = f;
        HScore = h;
    }

    
}