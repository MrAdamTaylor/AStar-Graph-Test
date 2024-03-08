using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public class ProbabilityCache<T>
    {
        public float[] ProbabilityData;
        public T[] PercantagesObjects;
        public float TotalSize;

        public void Construct(float[] percentages, T[] objects)
        {
            ProbabilityData = percentages;
            PercantagesObjects = objects;
            CalculateTotal(ProbabilityData);
        }

        private void CalculateTotal(float[] probabilityData)
        {
            for (int i = 0; i < probabilityData.Length; i++)
            {
                TotalSize += probabilityData[i];
            }
        }

        public void OutputData()
        {
            for (int i = 0; i < ProbabilityData.Length; i++)
            {
                Debug.Log($"Percentage {ProbabilityData[i]} and Object {PercantagesObjects[i]}");
            }
            Debug.Log($"Total Value {TotalSize}");
        }
    }
}