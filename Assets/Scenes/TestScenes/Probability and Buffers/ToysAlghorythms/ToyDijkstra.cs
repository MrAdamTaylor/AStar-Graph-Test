using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms
{
    class ToyDijkstra : IToyPathfinder
    {
        public ToyValues GetScores(ToyValues pastValue)
        {
            pastValue.Dijkstra = pastValue.Dijkstra + 1;
            Debug.Log("Сработал Dijkstra");
            return pastValue;
        }

        public void SayHello()
        {
            Debug.Log("Dijstra - передаёт вам привет");
        }
    }
}