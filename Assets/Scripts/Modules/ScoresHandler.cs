using System;
using UnityEngine;

public class ScoresHandler
{
    private struct CasheScores
    {
        public float GCache;
        public float HCache;
    }
    
    private static CasheScores _casheScores;
    
    public PathScores GetZeroScores()
    {
        PathScores scores = new PathScores(0,0,0);
        return scores;
    }

    

    public static float CalculateGValue(Vector2 curPos, Vector2 neighbour, float GCurNode)
    {
        float G = Vector2.Distance(curPos, neighbour) + GCurNode;
        if (_casheScores is Nullable<CasheScores>)
        {
            Debug.Log("Кеш очков не установлен");
            _casheScores = new CasheScores();
            _casheScores.GCache = G;
        }
        else
        {
            Debug.Log("Кеш очков установлен: (G)");
            _casheScores.GCache = G;
        }

        return G;
    }

    public static float CalculateHValue(Vector2 curPos, Vector2 neighbour)
    {
        float H = Vector2.Distance(curPos, neighbour);
        if (_casheScores is Nullable<CasheScores>)
        {
            Debug.Log("Кеш очков не установлен");
            _casheScores = new CasheScores();
            _casheScores.HCache = H;
        }
        else
        {
            Debug.Log("Кеш очков установлен: (H)");
            _casheScores.HCache = H;
        }
        return H;
    }

}

