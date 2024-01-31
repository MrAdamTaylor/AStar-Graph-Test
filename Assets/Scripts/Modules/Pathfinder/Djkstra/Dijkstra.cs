using LegacyCode.AStar;
using Modules.MazeGenerator.Data;

namespace Modules.Pathfinder.Djkstra
{
    class Dijkstra : IPathfinder
    {
        public PathScores GetPathScores(ScoresHandler _scoresHandler, MazePathMarker current, MazePathMarker goal, MapLocationStruct neighbour)
        {
            float g = ScoresHandler.CalculateGValue(current.location.ToVector(), neighbour.ToVector(), current.G);
            //float h = ScoresHandler.CalculateHValue(neighbour.ToVector(), goal.location.ToVector());
            float f = ScoresHandler.CalculateFValue();
            PathScores scores = _scoresHandler.GetScoresDijkstra(f,g);
            ScoresHandler.ClearCache();
            return scores;
        }
    }
}