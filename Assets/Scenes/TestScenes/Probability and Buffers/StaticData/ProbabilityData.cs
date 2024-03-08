using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ProbabilityGameObjectData", menuName = "Probability/ProbabilityData", order = 1)]
public class ProbabilityData : ScriptableObject
{
    public float[] Percantage;
    public GameObject[] ObjectsToSpawn;

    public (float[], GameObject[])LoadToData()
    {
        if (Percantage.AreArraysEqualSize(ObjectsToSpawn))
        {
            Debug.Log("Данные эквивалентны по размеру!");
            return (Percantage, ObjectsToSpawn);

        }
        else
        {
            if (Percantage.Length > ObjectsToSpawn.Length)
            {
                throw new Exception("Массив вероятностным данных не может быть выгружен! Добавьте ещё элементы объектов");
            }
            else
            {
                int newObjectsCount = Percantage.Length;
                ObjectsToSpawn = ObjectsToSpawn.Take(newObjectsCount).ToArray();
                Debug.LogWarning("Были взяты только первые объекты эквивалентные вероятностному распределению!");
                return (Percantage, ObjectsToSpawn);
            }

        }

    }
    
}


public static class ArrayExtensions
{
    public static bool AreArraysEqualSize<T,T1>(this T[] array1, T1[] array2)
    {
        if (array1 == null || array2 == null)
        {
            Debug.LogError("Массивы не должны быть равны нулю");
            //throw new ArgumentNullException("Both arrays must be non-null");
        }

        // Используем интерфейс IEnumerable для получения количества элементов
        int count1 = array1.GetCount();
        int count2 = array2.GetCount();

        // Сравниваем количество элементов
        return count1 == count2;
    }
    
    private static int GetCount<T>(this T[] array)
    {
        // Если массив null, то вернем 0, иначе подсчитаем количество элементов
        return array == null ? 0 : array.Length;
    }
}