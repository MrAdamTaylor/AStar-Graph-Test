using System.Linq;
using UnityEngine;

public class MazePathMarkerHandler : MonoBehaviour
{
    private IScoreWriter _scoreWriter;
    bool _isCountMyStep;
    
    TextMesh secondcache;
    TextMesh fcache;
    
    public void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
        {
            Destroy(m);
        }
    }


    public void SetText(GameObject pathBlock, PathScores scores)
    {
        TextMesh[] values = pathBlock.GetComponentsInChildren<TextMesh>();
        ChoseAlghorythm(scores, values);
        _scoreWriter.WriteScores();
    }

    //TODO - для дополнительных очков штрафов можно написать потом декоратор
    private void ChoseAlghorythm(PathScores scores, TextMesh[] values)
    {
        if (values.Length > PathFindConstants.MaxScoreCount)
        {
            Debug.LogWarning("Необходимы дополнительные обработчики или в маркере мусор!");
            TextMesh[] thirdvalue = values.Take(3).ToArray();
            TextMesh[] orderedScores = OrderAScroes(thirdvalue);
            _scoreWriter = new AStarScoreWriter(scores, orderedScores);
        }
        else if (values.Length == PathFindConstants.MaxScoreCount)
        {
            TextMesh[] orderedScores = OrderAScroes(values);
            _scoreWriter = new AStarScoreWriter(scores, orderedScores);
        }
        else if (values.Length == PathFindConstants.ScoreCount)
        {
            DecideBetweenTwoMethods(scores, values);
        }
        else
        {
            Debug.LogWarning("Неподходящий префаб!");
        }
    }

    private void DecideBetweenTwoMethods(PathScores scores, TextMesh[] values)
    {
        for (int i = 0; i < PathFindConstants.ScoreCount; i++)
        {
            if (values[i].gameObject.name == PathFindConstants.GScoreName)
            {
                _isCountMyStep = true;
                secondcache = values[i];
                continue;
            }

            if (values[i].gameObject.name == PathFindConstants.HScoreName)
            {
                secondcache = values[i];
                continue;
            }

            if (values[i].gameObject.name == PathFindConstants.FScoreName)
            {
                _isCountMyStep = true;
                fcache = values[i];
                continue;
            }
        }

        if (_isCountMyStep)
        {
            _scoreWriter = new DjkstraScoreWriter(scores, fcache, secondcache);
        }
        else
        {
            _scoreWriter = new GreedyBFSWriter(scores, fcache, secondcache);
        }
    }

    private TextMesh[] OrderAScroes(TextMesh[] values)
    {
        TextMesh[] ordered = new TextMesh[3];
        for (int i = 0; i < PathFindConstants.MaxScoreCount; i++)
        {
            if (values[i].gameObject.name == PathFindConstants.GScoreName)
            {
                ordered[0] = values[i];
                continue;
            }

            if (values[i].gameObject.name == PathFindConstants.HScoreName)
            {
                ordered[1] = values[i];
                continue;
            }
                
            if (values[i].gameObject.name == PathFindConstants.FScoreName)
            {
                ordered[2] = values[i];
                continue;
            }
        }

        return ordered;
    }
}

