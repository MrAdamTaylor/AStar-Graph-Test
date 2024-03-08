using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms
{
    class ToyAStar : IToyPathfinder
    {
        public ToyValues GetScores(ToyValues pastValue)
        {
            pastValue.AStar = pastValue.AStar + 1;
            Debug.Log("Сработал AStar");
            return pastValue;
        }

        public void SayHello()
        {
            Debug.Log("AStar - передаёт вам привет");
        }
    }
}