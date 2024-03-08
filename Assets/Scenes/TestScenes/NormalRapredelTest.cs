using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NormalRapredelTest : MonoBehaviour
{
    public float[] data;
    
    int arraySize = 20; // Размер массива
    float mean = 0.0f;   // Среднее значение
    float stdDev = 1.0f; // Стандартное отклонение


    private void Start()
    {
        //float[] normalArray = GenerateNormalDistributionArray(data, mean, stdDev);

        float[] normalArray = ConvertToNormalDistribution(data, mean, stdDev);
        for (int i = 0; i < normalArray.Length; i++)
        {
            Debug.Log("NormalOrder: " +  normalArray[i] + " Индекс: "+i);
        }
    }
    
    /*float[] GenerateNormalDistributionArray(float[] inputArray, float mean, float stdDev)
    {
        int size = inputArray.Length;
        float[] array = new float[size];

        for (int i = 0; i < size; i += 2)
        {
            float u1 = 1f - Random.Range(0f, 1f);// Равномерно распределенное число от 0 до 1
            float u2 = 1f - Random.Range(0f, 1f); // Равномерно распределенное число от 0 до 1

            float z0 = Mathf.Sqrt(-2f * Mathf.Log(u1)) * Mathf.Cos(2f * Mathf.PI * u2);
            float z1 = Mathf.Sqrt(-2f * Mathf.Log(u1)) * Mathf.Sin(2f * Mathf.PI * u2);

            array[i] = mean + z0 * stdDev * inputArray[i];
            
            // Для случайного
            /*if (i + 1 < size)
                array[i + 1] = mean + z1 * stdDev;#1#
            
            if (i + 1 < size)
                array[i + 1] = mean + z1 * stdDev * inputArray[i + 1];
        }

        return array;
    }*/
    
    static float[] ConvertToNormalDistribution(float[] array, float mean, float stdDev)
    {
        int size = array.Length;
        float[] normalArray = new float[size];

        for (int i = 0; i < size; i++)
        {
            float u1 = 1f - Random.Range(0f,1f); // Равномерно распределенное число от 0 до 1
            float u2 = 1f - Random.Range(0f,1f); // Равномерно распределенное число от 0 до 1

            float z = Mathf.Sqrt(-2f * Mathf.Log(u1)) * Mathf.Cos(2f * Mathf.PI * u2);

            normalArray[i] = mean + z * stdDev;
        }

        return normalArray;
    }
}
