using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Pathfinder.Djkstra;
using UnityEngine;

public class PathfinderInstaller : MonoBehaviour
{
    public Alghorythm Alghorythm;

    public void Start()
    {
        GameObject childObject = new GameObject("<AI>");

        childObject.transform.parent = transform;
        SwitchComponent(Alghorythm,childObject);
    }

    public void SwitchComponent(Alghorythm alghorythm, GameObject childObject)
    {
        switch (alghorythm)
        {
            case Alghorythm.Djkstra:
                ComponentDjkstra djkstra = childObject.AddComponent<ComponentDjkstra>();
                break;
            case Alghorythm.GBFS:
                ComponentGBFS gbfs = childObject.AddComponent<ComponentGBFS>();
                break;
            case Alghorythm.AStar:
                ComponentAStar astar = childObject.AddComponent<ComponentAStar>();
                break;
            case Alghorythm.Hybrid_AStar_GBFS:
                Component_GBFS_AStar astar_gbfs = childObject.AddComponent<Component_GBFS_AStar>();
                break;
            case Alghorythm.Hybrid_AStar_Dijkstra:
                Component_Djkstra_AStar astar_dijkstra = childObject.AddComponent<Component_Djkstra_AStar>();
                break;
            case Alghorythm.Hybrid_All:
                FullHybrid fullHybrid = childObject.AddComponent<FullHybrid>();
                break;
        }
    }
}

public enum Alghorythm
{
    Djkstra,
    AStar,
    GBFS,
    Hybrid_AStar_Dijkstra,
    Hybrid_AStar_GBFS,
    Hybrid_All
}



public class ComponentDjkstra : MonoBehaviour
{
    private IToyPathfinder _toyPathfinder;
    public void Start()
    {
        _toyPathfinder = new ToyDijkstra();
        _toyPathfinder.SayHello();
    }
}

public class ComponentAStar : MonoBehaviour
{
    private IToyPathfinder _toyPathfinder;
    public void Start()
    {
        _toyPathfinder = new ToyAStar();
        _toyPathfinder.SayHello();
    }
}

public class ComponentGBFS : MonoBehaviour
{
    private IToyPathfinder _toyPathfinder;
    public void Start()
    {
        _toyPathfinder = new ToyGBFS();
        _toyPathfinder.SayHello();
    }
}

public class Component_GBFS_AStar : MonoBehaviour
{
    private List<IToyPathfinder> _pathfinders;
    void Start()
    {
        _pathfinders = InterfaceHandler.GetInterfaceImplementations<IToyPathfinder>().ToList();

        foreach (var implementation in _pathfinders)
        {
            if(implementation is ToyDijkstra)
                continue;
            implementation.SayHello();
        }
    }
}

public class Component_Djkstra_AStar : MonoBehaviour
{
    private List<IToyPathfinder> _pathfinders;
    void Start()
    {
        _pathfinders = InterfaceHandler.GetInterfaceImplementations<IToyPathfinder>().ToList();

        foreach (var implementation in _pathfinders)
        {
            if(implementation is ToyGBFS)
                continue;
            implementation.SayHello();
        }
    }
}