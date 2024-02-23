using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitySpawner : MonoBehaviour
{
    [SerializeField] private float[] percentage;
    [SerializeField] private GameObject[] objectsToSpawn;

    [SerializeField] Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objectsToSpawn[GetRandomSpawn()], spawnPoint);
        }
    }

    private int GetRandomSpawn()
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < percentage.Length; i++)
        {
            total += percentage[i];
        }

        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            if (percentage[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentage[i] / total;
            }
        }

        return 0;
    }
}
