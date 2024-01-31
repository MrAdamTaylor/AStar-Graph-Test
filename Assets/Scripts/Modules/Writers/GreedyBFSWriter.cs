using Modules.Pathfinder;
using UnityEngine;

namespace Modules.Writers
{
    public class GreedyBFSWriter : IScoreWriter
    {
        private TextMesh _fString;
        private TextMesh _hString;
        private PathScores _scores;
        public GreedyBFSWriter(PathScores scores,TextMesh f, TextMesh h)
        {
            _fString = f;
            _hString = h;
            _scores = scores;
        }

        public void WriteScores()
        {
            _hString.text = "H: " + _scores.GScore.ToString("0.00");
            _fString.text = "F: " + _scores.GScore.ToString("0.00"); 
        }
    }
}