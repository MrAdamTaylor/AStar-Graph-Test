using UnityEngine;

namespace Modules.MazeHeuristicHandler.AbstractFactory
{
    class IMazeProceduralCreater : IMazeMarkCreaterService
    {
        public GameObject CreateStartMarker()
        {
            throw new System.NotImplementedException();
        }

        public GameObject CreateFinishMarker()
        {
            throw new System.NotImplementedException();
        }

        public GameObject CreateIntermediateMarker()
        {
            throw new System.NotImplementedException();
        }
    }
}