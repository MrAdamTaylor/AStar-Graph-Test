using System;
using UnityEngine;

public class ScoresHandler
{
    private class CasheScores
    {
        public float GCache;
        public float HCache;

        public void AddGValue()
        {
            GCache = 0;
            HCache = 0;
        }

    }
    
    private static CasheScores _casheScores;
    
    public PathScores GetZeroScores()
    {
        PathScores scores = new PathScores(0.0f,0.0f,0.0f);
        return scores;
    }

    public static float CalculateGValue(Vector2 curPos, Vector2 neighbour, float GCurNode)
    {
        float G = Vector2.Distance(curPos, neighbour) + GCurNode;
        if (_casheScores is null)
        {
            Debug.Log("Кеш очков не установлен");
            _casheScores = new CasheScores();
            _casheScores.GCache = G;
        }
        else
        {
            Debug.Log("Кеш очков установлен : до (G)");
            _casheScores.GCache = G;
        }

        return G;
    }

    public static float CalculateHValue(Vector2 curPos, Vector2 neighbour)
    {
        float H = Vector2.Distance(curPos, neighbour);
        if (_casheScores is null)
        {
            Debug.Log("Кеш очков не установлен");
            _casheScores = new CasheScores();
            _casheScores.HCache = H;
        }
        else
        {
            Debug.Log("Кеш очков установлен: до (H)");
            _casheScores.HCache = H;
        }
        return H;
    }

    public static float CalculateFValue()
    {
        float f = _casheScores.GCache + _casheScores.HCache;
        return f;
    }

    public static void ClearCache()
    {
        _casheScores = null;
    }

    public PathScores GetScoresDataAStar(float f, float g, float h)
    {
        PathScores scores = new PathScores(g,f,h);
        return scores;
    }
}

