using Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms;
using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public class ComponentGBFS : MonoBehaviour
    {
        private IToyPathfinder _toyPathfinder;
        public void Start()
        {
            _toyPathfinder = new ToyGBFS();
            _toyPathfinder.SayHello();
        }
    }
}