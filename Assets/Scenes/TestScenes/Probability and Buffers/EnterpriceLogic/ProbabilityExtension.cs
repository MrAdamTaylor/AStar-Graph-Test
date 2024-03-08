using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers.MonoComponents
{
    public static class ProbabilityExtension
    {
        public static int[] GetProbabilityFromRange(this float range, int accuracy)
        {
            int[] buf = new int[2];
            for (int i = 0; i < buf.Length; i++)
            {
                if (i == 1)
                {
                    float temp = (1 - range) * accuracy;
                    buf[i] = Mathf.CeilToInt(temp);
                }
                else
                {
                    float temp = range * accuracy;
                    buf[i] = Mathf.CeilToInt(temp);

                }
            }
            return buf;
        }
        
        
    }
}