using Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms;
using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public class ComponentAStar : MonoBehaviour
    {
        private IToyPathfinder _toyPathfinder;
        public void Start()
        {
            _toyPathfinder = new ToyAStar();
            _toyPathfinder.SayHello();
        }
    }
}