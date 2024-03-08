using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Scenes.TestScenes.Probability_and_Buffers.EnterpriceLogic;
using Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms;
using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public class ComponentFullHybrid : MonoBehaviour
    {
        [Header("0 - Dijkstra, 1 - AStar, 2 - GBFS")]
        
        [Range(HybridPathfinderConstants.MIN_Range_Value, HybridPathfinderConstants.MAX_Range_Value)] 
        [SerializeField] private float _alghorythmBehaviour = HybridPathfinderConstants.Default_Value;
        [Header("1 - 5step, 2 - 10step, 3 - 20step, 4 - 25step, 5 - 50step, 6 - 100step")]
        
        [Range(1, 6)] [SerializeField] private int _accuracy = HybridPathfinderConstants.Default_Accuracy;
        private List<IToyPathfinder> _pathfinders;
        private int _innerAccuracy;
        private float _range;

        void Start()
        {
            _pathfinders = InterfaceHandler.GetInterfaceImplementations<IToyPathfinder>().ToList();

            foreach (var implementation in _pathfinders)
            {
                implementation.SayHello();
            }
        }
        void Update()
        {
            _innerAccuracy = _accuracy.AccuracyInterpretator();
            _range = _alghorythmBehaviour.GetTriangleRange(HybridPathfinderConstants.PICK_Range_Value, 
                HybridPathfinderConstants.MAX_Range_Value);
            //Debug.Log("Range: "+_range +"Alghorithm Behaviour: "+_alghorythmBehaviour);
            int[] probability = _range.GetProbabilityFromRange(_innerAccuracy);
            for (int i = 0; i < probability.Length; i++)
            {
                Debug.Log("Probability: " + probability[i] + " with index "+i);
            }
        }
    }

    public class ProbabilityPatchBuffer
    {
        private ProbabilityCache<IToyPathfinder> _cache;
        private IToyPathfinder _mainBuffer;
        private IToyPathfinder _secondBuffer;
        private IToyPathfinder _backupBuffer;

        public void Construct(ProbabilityCache<IToyPathfinder> cache)
        {
            _cache = cache;
        }
        
    }

}