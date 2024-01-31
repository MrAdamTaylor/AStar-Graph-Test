using LegacyCode.AStar;
using Modules.MazeGenerator.Data;

namespace Modules.Pathfinder
{
    public interface IPathfinder
    {
        public PathScores GetPathScores(ScoresHandler _scoresHandler, MazePathMarker current, MazePathMarker goal, MapLocationStruct neighbour);
    }
}