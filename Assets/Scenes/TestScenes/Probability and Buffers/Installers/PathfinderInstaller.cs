using System.Collections.Generic;
using System.Linq;
using Scenes.TestScenes.Probability_and_Buffers.EnterpriceLogic;
using Scenes.TestScenes.Probability_and_Buffers.MonoComponents;
using Scenes.TestScenes.Probability_and_Buffers.ToysAlghorythms;
using UnityEngine;

namespace Scenes.TestScenes.Probability_and_Buffers
{
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
                    ComponentFullHybrid componentFullHybrid = childObject.AddComponent<ComponentFullHybrid>();
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


    public class Component_GBFS_AStar : MonoBehaviour
    {
        [Header("0 - GBFS, 1- AStar")]
        [Range(0f, 1f)] [SerializeField] private float _alghorythmBehaviour = 1f;
        [Header("1 - 5step, 2 - 10step, 3 - 20step, 4 - 25step, 5 - 50step, 6 - 100step")]
        [Range(1, 6)] [SerializeField] private int _accuracy = 1;
    
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
        [Header("0 - Dijkstra, 1 - AStar")]
        [Range(0f, 1f)] [SerializeField] private float _alghorythmBehaviour = 1f;
        [Header("1 - 5step, 2 - 10step, 3 - 20step, 4 - 25step, 5 - 50step, 6 - 100step")]
        [Range(1, 6)] [SerializeField] private int _accuracy = 1;
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
}