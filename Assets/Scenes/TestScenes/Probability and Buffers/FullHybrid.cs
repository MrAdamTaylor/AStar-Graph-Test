using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FullHybrid : MonoBehaviour
{
    private List<IToyPathfinder> _pathfinders;
    void Start()
    {
        _pathfinders = InterfaceHandler.GetInterfaceImplementations<IToyPathfinder>().ToList();

        foreach (var implementation in _pathfinders)
        {
            implementation.SayHello();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ProbabilityBuffer
{
    
}

public static class InterfaceHandler
{
    public static IEnumerable<T> GetInterfaceImplementations<T>()
    {
        Type interfaceType = typeof(T);

        // Получаем все типы в текущей сцене
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes());

        foreach (var type in types)
        {
            // Проверяем, является ли тип классом и реализует ли интерфейс
            if (type.IsClass && interfaceType.IsAssignableFrom(type))
            {
                // Создаем экземпляр класса и возвращаем его
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}

public struct ToyValues
{
    public int GBFS;
    public int AStar;
    public int Dijkstra;
}

public interface IToyPathfinder
{
    public ToyValues GetScores(ToyValues pastValue);

    public void SayHello();
}

class ToyAStar : IToyPathfinder
{
    public ToyValues GetScores(ToyValues pastValue)
    {
        pastValue.AStar = pastValue.AStar + 1;
        Debug.Log("Сработал AStar");
        return pastValue;
    }

    public void SayHello()
    {
        Debug.Log("AStar - передаёт вам привет");
    }
}

class ToyDijkstra : IToyPathfinder
{
    public ToyValues GetScores(ToyValues pastValue)
    {
        pastValue.Dijkstra = pastValue.Dijkstra + 1;
        Debug.Log("Сработал Dijkstra");
        return pastValue;
    }

    public void SayHello()
    {
        Debug.Log("Dijstra - передаёт вам привет");
    }
}

class ToyGBFS : IToyPathfinder
{
    public ToyValues GetScores(ToyValues pastValue)
    {
        pastValue.GBFS = pastValue.GBFS + 1;
        Debug.Log("Сработал GBFS");
        return pastValue;
    }

    public void SayHello()
    {
        Debug.Log("GBFS - передаёт вам привет");
    }
}
