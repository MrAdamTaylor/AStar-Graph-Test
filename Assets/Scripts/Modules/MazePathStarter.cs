using System.Collections;
using System.Collections.Generic;
using Modules.MazeGenerator;
using Unity.VisualScripting;
using UnityEngine;

public class MazePathStarter : MonoBehaviour
{
    [SerializeField] private MarksCreater _marksCreater;
    [SerializeField] private MazeGenerator _maze;

    #region Материалы 
        //public Material closedMaterial;
        //public Material openMaterial;
    #endregion

    #region Открытые и закрытые списки

    private OpenMapList _openMapList;
    private ClosedMapList _closedMapList;

    #endregion

    private bool _done = false;
    private MazeData _data;

    private byte[,] _mapData;
    //private List<MapLocationStruct> _uselocations;

    private MazePathMarker _goalNode;
    private MazePathMarker _startNode;
    
    private MazeLocations _locations;
    private ScoresHandler _scoresHandler;
    private MazePathMarkerHandler _mazePathMarkerHandler;
    private MazePathMarker _lastNode;

    void Start()
    {
        _data = _maze.MazePack;
        _mapData = (byte[,])MazeServiceLocator.Instance.GetData(typeof(byte[,]));
        _scoresHandler = new ScoresHandler();
        //_locations = new MazeLocations(_data);
        _locations = new MazeLocations(_mapData, _data);

        _openMapList = new OpenMapList();
        _closedMapList = new ClosedMapList();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BeginSearch();
        }
    }

    private void BeginSearch()
    {
        _done = false;
        RemoveAllMarkers();
        _locations.Shuffle();
        Vector3 startPos = new Vector3(_locations.GetXByIndex(0) * _data.Scale, 0, _locations.GetZByIndex(0) * _data.Scale);
        _startNode = new MazePathMarker(
            new MapLocationStruct(_locations.GetXByIndex(0) * _data.Scale,_locations.GetZByIndex(0) * _data.Scale),
            _scoresHandler.GetZeroScores(), _marksCreater.CreateStart(startPos), null
        );
        Vector3 finishPos = new Vector3(_locations.GetXByIndex(1) * _data.Scale, 0, _locations.GetXByIndex(1) * _data.Scale);
        _goalNode = new MazePathMarker(
            new MapLocationStruct(_locations.GetXByIndex(1) * _data.Scale,_locations.GetXByIndex(1) * _data.Scale),
            _scoresHandler.GetZeroScores(), _marksCreater.CreateFinish(finishPos), null
        );
        
        _openMapList.Clear();
        _closedMapList.Clear();
        _openMapList.Add(_startNode);
        _lastNode = _startNode;

        //TODO - здесь происходит прощёт ошибок, скорее всего из - за недостоверной передачи данных о состоянии лабиринта
        //Search(_startNode);
    }

    private void TestScoresCalculate()
    {
        
    }

    public void Search(MazePathMarker thisNode)
    {
        if (thisNode.Equals(_goalNode))
        {
            _done = true;
            return;
        }

        foreach(MapLocationStruct dir in Directions.directions)
        {
            MapLocationStruct neighbour = dir + thisNode.location;
            //TODO - тоже можно вынести в одтельный сервис, так как используется при генерации
            //Проверка ближайшего окружение
            if (_maze.MazePack.Map[neighbour.x, neighbour.z] == 1)
            {
                //Сосед стена
                continue;
            }
            //TODO - вынести это потом в BorderHandler
            //Проверка пределов
            if (neighbour.x < 1 || neighbour.x >= _maze.MazePack.Width || neighbour.z < 1 
                || neighbour.z >= _maze.MazePack.Depth)
            {
                continue;
            }
            //Проверка - нет ли среди закрытых листов
            if (_closedMapList.IsClodes(neighbour))
            {
                continue;
            }

            ScoresHandler.CalculateGValue(thisNode.location.ToVector(), neighbour.ToVector(), thisNode.G);
            ScoresHandler.CalculateHValue(thisNode.location.ToVector(), neighbour.ToVector());
        }
    }

    private void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
        {
            Destroy(m);
        }
    }
}


public class ClosedMapList
{
    private List<MazePathMarker> _closed;

    public void Add(MazePathMarker pathMarker)
    {
        if (_closed is null)
        {
            _closed = new List<MazePathMarker>();
        }
        _closed.Add(pathMarker);
    }

    public void Clear()
    {
        if (_closed is null)
        {
            return;
        }
        else
        {
            _closed.Clear();
        }
    }

    public bool IsClodes(MapLocationStruct marker)
    {
        foreach (MazePathMarker path in _closed)
        {
            //TODO - надо проверить в первоисточниках, не используется ли этот метод
            if (path.location.Equals(marker))
                return true;
        }
        return false;
    }
}

public class OpenMapList
{
    private List<MazePathMarker> _open;

    public void Add(MazePathMarker pathMarker)
    {
        if (_open is null)
        {
            _open = new List<MazePathMarker>();
        }
        _open.Add(pathMarker);
    }
    
    public void Clear()
    {
        if (_open is null)
        {
            return;
        }
        else
        {
            _open.Clear();
        }
    }
}

public class MazePathMarkerHandler
{
    
}