using Modules.Pathfinder;
using UnityEngine;

namespace Modules.Writers
{
    public class DjkstraScoreWriter : IScoreWriter
    {
        private TextMesh _fString;
        private TextMesh _gString;
        private PathScores _scores;
        public DjkstraScoreWriter(PathScores scores, TextMesh f, TextMesh g)
        {
            _gString = g;
            _fString = f;
            _scores = scores;
        }

        public void WriteScores()
        {
            _gString.text = "G: " + _scores.GScore.ToString("0.00");
            _fString.text = "F: " + _scores.GScore.ToString("0.00"); 
        }
    }
}