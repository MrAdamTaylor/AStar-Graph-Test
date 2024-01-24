using Modules.MazeGenerator;
using UnityEngine;

class IMazeLoader : IMazeMarkCreaterService
{
    public GameObject CreateStartMarker()
    {
        Debug.Log("Создан стартовый объект");
        GameObject start = Resources.Load<GameObject>(MazeHandlersConstants.StartMarkPrefabPath);
        return start;
    }

    public GameObject CreateFinishMarker()
    {
        Debug.Log("Создан финишный объект");
        GameObject finish = Resources.Load<GameObject>(MazeHandlersConstants.FinishMarkPrefabPath);
        return finish;
    }

    public GameObject CreateIntermediateMarker()
    {
        Debug.Log("Создан промежуточный объект");
        GameObject intermediate = Resources.Load<GameObject>(MazeHandlersConstants.IntermediateMarkPrefabPath);
        return intermediate;
    }
}