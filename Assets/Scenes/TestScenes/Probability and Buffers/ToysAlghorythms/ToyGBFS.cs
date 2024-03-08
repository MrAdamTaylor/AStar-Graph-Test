using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms
{
    class ToyGBFS : IToyPathfinder
    {
        public ToyValues GetScores(ToyValues pastValue)
        {
            pastValue.GBFS = pastValue.GBFS + 1;
            Debug.Log("Сработал GBFS");
            return pastValue;
        }

        public void SayHello()
        {
            Debug.Log("GBFS - передаёт вам привет");
        }
    }
}