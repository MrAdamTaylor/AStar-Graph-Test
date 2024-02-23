using LegacyCode.AStar;
using Modules.MazeGenerator.Data;
using Modules.MazeHeuristicHandler;
using Modules.MazeHeuristicHandler.Services;
using Modules.Pathfinder;
using Modules.Pathfinder.AStar;
using Modules.Pathfinder.BFS;
using Modules.Pathfinder.Djkstra;
using UnityEngine;

public enum AlghorythmChoiseType
{
    Probability
}

namespace Modules
{
    public class MazePathStarter : MonoBehaviour
    {
        [Range(0, 2)] 
        [SerializeField] private float _alghorythmBehaviour;

        [Header("Точность")]
        [Range(10, 100)] 
        [SerializeField] private float _strenghtProbability;
        
        
        [SerializeField] private PathfinderTypes _pathfinderType;
        [SerializeField] private string _explorersParentName;
        [SerializeField] private string _pathParentName;
    
        [SerializeField] private MarksCreater _marksCreater;
        [SerializeField] private MazeGenerator.Generator.MazeGenerator _maze;
        [SerializeField] private MazePathMarkerHandler _mazePathMarkerHandler;
        [SerializeField] private MazeMarkShellCreater _shellMarkCreater;

        #region Открытые и закрытые списки
        private OpenMapList _openMapList;
        private ClosedMapList _closedMapList;
        #endregion

        #region для красоты в иерархии
        private GameObject _explorersMarksParent;
        private GameObject _pathMarksParent;
        #endregion  
    
        private bool _done = false;
        private MazeData _data;

        #region Все возможноые маркеры

        private MazePathMarker _goalNode;
        private MazePathMarker _startNode;
        private MazePathMarker _lastNode;

        private IPathfinder _pathfinder;
    
        #endregion
    
    
        private MazeLocations _locations;
        private ScoresHandler _scoresHandler;
    

        void Start()
        {
            _data = _maze.MazePack;
            _scoresHandler = new ScoresHandler();
            _locations = new MazeLocations(_data);
            _openMapList = new OpenMapList();
            _closedMapList = new ClosedMapList();
            ChoseAlghorythm();
            ChoseAlghorythmByProbability(_alghorythmBehaviour, _strenghtProbability);
        }

        private void ChoseAlghorythmByProbability(float behaviour, float strenght)
        {
            
        }


        private void ChoseAlghorythm()
        {
            if (_pathfinderType == PathfinderTypes.AStar)
            {
                _pathfinder = new AStar();
            }
            else if (_pathfinderType == PathfinderTypes.Dijkstra)
            {
                _pathfinder = new Dijkstra();
            }
            else
            {
                _pathfinder = new GreedyBFS();
            }
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                BeginSearch();
            }

            if (Input.GetKeyDown(KeyCode.C) && !_done)
            {
                Search(_lastNode);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                GetPath();
            }
        }

        private void GetPath()
        {
            _pathMarksParent = new GameObject(_pathParentName);
            _mazePathMarkerHandler.RemoveAllMarkers();
            MazePathMarker begin = _lastNode;

            while (!_startNode.Equals(begin) && begin != null)
            {
                Vector3 pos = new Vector3(begin.location.x * _maze.MazePack.Scale, 0,
                    begin.location.z * _maze.MazePack.Scale);
                GameObject mark = _marksCreater.CreateIntermediate(pos);
                mark.transform.parent = _pathMarksParent.transform;
                begin = begin.parent;
            }

            Vector3 lastpos = new Vector3(begin.location.x * _maze.MazePack.Scale, 0,
                _startNode.location.z * _maze.MazePack.Scale);
            GameObject lastMark = _marksCreater.CreateIntermediate(lastpos);
            lastMark.transform.parent = _pathMarksParent.transform;
        }

        private void BeginSearch()
        {
            _done = false;
            _mazePathMarkerHandler.RemoveAllMarkers();
            _locations.Shuffle();

            _startNode = _shellMarkCreater.GetFirstShell(_locations.GetXByIndex(0), _locations.GetZByIndex(0),
                _data.Scale, _marksCreater, _scoresHandler.GetZeroScores());

            _goalNode = _shellMarkCreater.GetFinishShell(_locations.GetXByIndex(1), _locations.GetZByIndex(1),
                _data.Scale, _marksCreater, _scoresHandler.GetZeroScores());
        
            _openMapList.Clear();
            _closedMapList.Clear();
            _openMapList.Add(_startNode);
            _lastNode = _startNode;
            _explorersMarksParent = new GameObject(_explorersParentName);
        }

        public void Search(MazePathMarker thisNode)
        {
            if(thisNode == null) return;
            if (thisNode.Equals(_goalNode))
            {
                _done = true;
                return;
            }

            foreach(MapLocationStruct dir in Directions.directions)
            {
                MapLocationStruct neighbour = dir + thisNode.location;
                //TODO - тоже можно вынести в одтельный сервис, так как используется при генерации
                if (_maze.MazePack.Map[neighbour.x, neighbour.z] == 1) continue;
                //TODO - вынести это потом в BorderHandler
                if (neighbour.x < 1 || neighbour.x >= _maze.MazePack.Width || neighbour.z < 1 
                    || neighbour.z >= _maze.MazePack.Depth) continue;
                if (_closedMapList.IsClodes(neighbour)) continue;
                
                PathScores scores = _pathfinder.GetPathScores(_scoresHandler, thisNode, _goalNode, neighbour);
            
            
                //Создание объекта
                Vector3 intermediatePos = new Vector3(neighbour.x * _data.Scale, 0, neighbour.z * _data.Scale);
                GameObject pathBlock = _marksCreater.CreateIntermediate(intermediatePos);
                pathBlock.transform.parent = _explorersMarksParent.transform;
            
                //Установка текста
                _mazePathMarkerHandler.SetText(pathBlock, scores);
            
                //
                if (!UpdateMarker(neighbour, scores, thisNode))
                {
                    _openMapList.Add(_shellMarkCreater.GetMarkShell(neighbour, scores, pathBlock, thisNode));
                }
            }
            MazePathMarker pathMarker = _openMapList.GetBestElement();
        
            _closedMapList.Add(pathMarker);

            _openMapList.RemoveFirstElement();
            _mazePathMarkerHandler.StitchToClosedMaterial(pathMarker);
        
            _lastNode = pathMarker;
        }

        private bool UpdateMarker(MapLocationStruct neighbour, PathScores getScoresDataAStar, MazePathMarker thisNode)
        {
            if (_openMapList.CheckByUpdate(neighbour, getScoresDataAStar, thisNode))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}