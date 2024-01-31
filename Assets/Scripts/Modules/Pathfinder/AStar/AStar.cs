using LegacyCode.AStar;
using Modules.MazeGenerator.Data;

namespace Modules.Pathfinder.AStar
{
    class AStar : IPathfinder
    {
        public PathScores GetPathScores(ScoresHandler _scoresHandler, MazePathMarker current, MazePathMarker goal, MapLocationStruct neighbour)
        {
            float g = ScoresHandler.CalculateGValue(current.location.ToVector(), neighbour.ToVector(), current.G);
            float h = ScoresHandler.CalculateHValue(neighbour.ToVector(), goal.location.ToVector());
            float f = ScoresHandler.CalculateFValue();
            PathScores scores = _scoresHandler.GetScoresDataAStar(f,g,h);
            ScoresHandler.ClearCache();
            return scores;
        }
    }
}