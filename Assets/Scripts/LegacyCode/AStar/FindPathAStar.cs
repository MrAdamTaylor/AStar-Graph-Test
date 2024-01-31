using System.Collections.Generic;
using System.Linq;
using Modules.Extensions;
using UnityEngine;

namespace LegacyCode.AStar
{
    public class FindPathAStar : MonoBehaviour
    {
        //TODO - лабиринт Maze надо будет заинджектить!
        public Maze maze;
        public Material closedMaterial;
        public Material openMaterial;

        private List<PathMarker> open = new List<PathMarker>();
        private List<PathMarker> closed = new List<PathMarker>();

        #region Маркеры, которые будут ставится
    
        public GameObject start;
        public GameObject end;
        public GameObject pathP;
    
        #endregion
    
        private PathMarker _goalNode;
        private PathMarker _startNode;

        private PathMarker _lastNode;
        private bool _done = false;

        void BeginSearch()
        {
            _done = false;
            RemoveAllMarkers();

            List<MapLocation> locations = new List<MapLocation>();
            for (int z = 1; z < maze.depth - 1; z++)
            for (int x = 1; x < maze.width - 1; x++)
            {
                if (maze.map[x, z] != 1)
                {
                    //TODO 
                    locations.Add(new MapLocation(x,z));
                }

            }
        
            locations.Shuffle();

            Vector3 startLocation = new Vector3(locations[0].x * maze.scale, 0, locations[0].z * maze.scale);
            _startNode = new PathMarker(new MapLocation(locations[0].x, locations[0].z), 
                0, 0, 0, Instantiate(start, startLocation, Quaternion.identity), null);

            Vector3 finishLocation = new Vector3(locations[1].x * maze.scale, 0, locations[1].z * maze.scale);
            _goalNode = new PathMarker(new MapLocation(locations[1].x, locations[1].z), 
                0, 0, 0, Instantiate(end, finishLocation, Quaternion.identity), null);
        
            open.Clear();
            closed.Clear();
            open.Add(_startNode);
            _lastNode = _startNode;
            //Search(_lastNode);
        }

        void Search(PathMarker thisNode)
        {
            #region Проверка на то, что алгоритм существует

            if(thisNode == null)
                return;

            #endregion
        
        
            if (thisNode.Equals(_goalNode))
            {
                _done = true;
                return;
            }

            foreach (MapLocation dir in maze.directions)
            {
                MapLocation neighbour = dir + thisNode.location;
                if(maze.map[neighbour.x, neighbour.z] == 1) continue;
                if (neighbour.x < 1 || neighbour.x >= maze.width || neighbour.z < 1 || neighbour.z >= maze.depth) continue;
                if(IsClosed(neighbour)) continue;

                float G = Vector2.Distance(thisNode.location.ToVector(), neighbour.ToVector()) + thisNode.G;
                float H = Vector2.Distance(neighbour.ToVector(), _goalNode.location.ToVector());
                float F = G + H;
                Debug.Log($"G-Value: {G}, H-Value: {H}, F-Value: {F}");

                GameObject pathBlock = Instantiate(pathP, new Vector3(neighbour.x * maze.scale, 0,
                    neighbour.z * maze.scale), Quaternion.identity);

                TextMesh[] values = pathBlock.GetComponentsInChildren<TextMesh>();
                values[0].text = "G " + G.ToString("0.00");
                values[1].text = "H " + H.ToString("0.00");
                values[2].text = "F " + F.ToString("0.00");

                #region MyRegion

                if(!UpdateMarker(neighbour, G, H, F, thisNode))
                    open.Add(new PathMarker(neighbour, G, H, F, pathBlock, thisNode));

                #endregion
            
            }

            #region Добавление нового элемента
            open = open.OrderBy(p => p.F).ToList<PathMarker>();
            PathMarker pm = open.ElementAt(0);
            closed.Add(pm);
            #endregion
        
        
            open.RemoveAt(0);
            pm.marker.GetComponent<Renderer>().material = closedMaterial;

            _lastNode = pm;
        }

        bool UpdateMarker(MapLocation pos, float g, float h, float f, PathMarker prt)
        {
            foreach (PathMarker p in open)
            {
                if (p.location.Equals(pos))
                {
                    p.G = g;
                    p.H = h;
                    p.F = f;
                    p.parent = prt;
                    return true;
                }
            }
            return false;
        }

        private bool IsClosed(MapLocation marker)
        {
            foreach (PathMarker p in closed)
            {
                if (p.location.Equals(marker)) return true;
            }
            return false;
        }

        void RemoveAllMarkers()
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
            foreach (GameObject m in markers)
            {
                Destroy(m);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                BeginSearch();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Search(_lastNode);
            }
        }
    }

    public class PathMarker
    {
        public MapLocation location;
        public float G;
        public float H;
        public float F;
        public GameObject marker;
        public PathMarker parent;

        public PathMarker(MapLocation l, float g, float h, float f, GameObject marker, PathMarker p)
        {
            location = l;
            G = g;
            H = h;
            F = f;
            this.marker = marker;
            parent = p;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return location.Equals(((PathMarker)obj).location);
            }
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}