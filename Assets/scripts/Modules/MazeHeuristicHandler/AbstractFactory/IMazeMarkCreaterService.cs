using UnityEngine;

namespace Modules.MazeHeuristicHandler.AbstractFactory
{
    public interface IMazeMarkCreaterService
    {
        GameObject CreateStartMarker();
        GameObject CreateFinishMarker();
        GameObject CreateIntermediateMarker();
    }
}