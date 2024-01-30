using UnityEngine;

public class AStarScoreWriter : IScoreWriter
{
    private TextMesh _fString;
    private TextMesh _gString;
    private TextMesh _hString;
    private PathScores _scores;
    public AStarScoreWriter(PathScores scores, TextMesh[] values)
    {
        _scores = scores;
        _gString = values[0];
        _hString = values[1];
        _fString = values[2];
    }

    public void WriteScores()
    {
        _gString.text = "G: " + _scores.GScore.ToString("0.00");
        _hString.text = "H: " + _scores.HScore.ToString("0.00");
        _fString.text = "F: " + _scores.FScore.ToString("0.00"); 
    }
}