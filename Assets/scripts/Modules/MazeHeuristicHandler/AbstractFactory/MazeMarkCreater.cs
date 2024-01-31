using UnityEngine;

namespace Modules.MazeHeuristicHandler.AbstractFactory
{
    public partial class MazeMarkCreater
    {
        private IMazeMarkCreaterService _mazeMarkCreaterService;

        public MazeMarkCreater(IMazeMarkFactory factory)
        {
            _mazeMarkCreaterService = factory.LoadMarkCreaterService();
        }

        public GameObject CreateStart()
        {
            GameObject startMarker = _mazeMarkCreaterService.CreateStartMarker();
            return startMarker;
        }

        public GameObject CreateFinish()
        {
            GameObject finishMarker = _mazeMarkCreaterService.CreateFinishMarker();
            return finishMarker;
        }

        public GameObject CreateIntermediate()
        {
            GameObject intermediateMarker = _mazeMarkCreaterService.CreateIntermediateMarker();
            return intermediateMarker;
        }

    }
}