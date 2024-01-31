using LegacyCode.AStar;
using Modules.MazeGenerator.Data;
using Modules.MazeHeuristicHandler.Services;
using Modules.Pathfinder;
using UnityEngine;

namespace Modules.MazeHeuristicHandler
{
    public class MazeMarkShellCreater : MonoBehaviour
    {
        public MazePathMarker GetMarkShell(MapLocationStruct map, PathScores scores, GameObject innerObj, MazePathMarker parent)
        {
            return new MazePathMarker(map, scores, innerObj, parent);
        }

        public MazePathMarker GetFirstShell(int xHeuristic, int yHeuristic, int scale, IMarksCreater marksCreater, PathScores scores)
        {
            Vector3 startPos = GetVector(xHeuristic, yHeuristic, scale);
            MapLocationStruct heuristicData = GetHeuristicPos(xHeuristic, yHeuristic);
            return new MazePathMarker(heuristicData, scores, marksCreater.CreateStart(startPos), null);
        }
    
        public MazePathMarker GetFinishShell(int xHeuristic, int yHeuristic, int scale, IMarksCreater marksCreater, PathScores scores)
        {
            Vector3 startPos = GetVector(xHeuristic, yHeuristic, scale);
            MapLocationStruct heuristicData = GetHeuristicPos(xHeuristic, yHeuristic);
            return new MazePathMarker(heuristicData, scores, marksCreater.CreateFinish(startPos), null);
        }

        public MapLocationStruct GetHeuristicPos(int xValue, int zValue)
        {
            return new MapLocationStruct(xValue, zValue);
        }
    
        public Vector3 GetVector(float xValue, float zValue, float scale)
        {
            return new Vector3(xValue * scale, 0.0f, zValue * scale);
        }
    }
}