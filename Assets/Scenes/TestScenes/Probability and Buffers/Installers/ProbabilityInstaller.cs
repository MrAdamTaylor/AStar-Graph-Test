using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers
{
    public class ProbabilityInstaller : MonoBehaviour
    {
        public void Start()
        {
            GameObject childObject = new GameObject("<Spawner>");

            childObject.transform.parent = transform;
            ProbabilitySpawerWithArchitecture spawner = childObject.AddComponent<ProbabilitySpawerWithArchitecture>();
        }

    
    }
}