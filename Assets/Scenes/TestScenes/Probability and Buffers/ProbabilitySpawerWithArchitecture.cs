using System;
using Scenes.TestScenes.Probability_and_Buffers.MonoComponents;
using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers
{
    public class ProbabilitySpawerWithArchitecture : MonoBehaviour
    {
        public void Start()
        {
            ProbabilityData data = Resources.Load<ProbabilityData>("ProbabilityObjectConfig/ProbabilityGameObjectData");
            var probabilityData = data.LoadToData();
            ProbabilityCache<GameObject> cache = new ProbabilityCache<GameObject>();
            cache.Construct(probabilityData.Item1, probabilityData.Item2);
            cache.OutputData();
        }
    }
}

