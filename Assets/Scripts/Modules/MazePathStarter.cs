using System;
using System.Collections;
using Modules.MazeGenerator;
using Unity.VisualScripting;
using UnityEngine;

public class MazePathStarter : MonoBehaviour
{
    [SerializeField] private MarksCreater _marksCreater;
    [SerializeField] private MazeGenerator _maze;
    [SerializeField] private MazePathMarkerHandler _mazePathMarkerHandler;

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
    //private MazePathMarkerHandler _mazePathMarkerHandler;
    private MazePathMarker _lastNode;

    void Start()
    {
        _data = _maze.MazePack;
        _scoresHandler = new ScoresHandler();
        _locations = new MazeLocations(_data);
        _openMapList = new OpenMapList();
        _closedMapList = new ClosedMapList();
    }

    
    void Update()
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

    private void BeginSearch()
    {
        _done = false;
        _mazePathMarkerHandler.RemoveAllMarkers();
        //RemoveAllMarkers();
        _locations.Shuffle();
        Vector3 startPos = new Vector3(_locations.GetXByIndex(0) * _data.Scale, 0.0f, _locations.GetZByIndex(0) * _data.Scale);
        _startNode = new MazePathMarker(
            new MapLocationStruct(_locations.GetXByIndex(0),_locations.GetZByIndex(0)),
            _scoresHandler.GetZeroScores(), _marksCreater.CreateStart(startPos), null
        );
        Vector3 finishPos = new Vector3(_locations.GetXByIndex(1) * _data.Scale, 0.0f, _locations.GetXByIndex(1) * _data.Scale);
        _goalNode = new MazePathMarker(
            new MapLocationStruct(_locations.GetXByIndex(1),_locations.GetXByIndex(1)),
            _scoresHandler.GetZeroScores(), _marksCreater.CreateFinish(finishPos), null
        );
        _openMapList.Clear();
        _closedMapList.Clear();
        _openMapList.Add(_startNode);
        _lastNode = _startNode;
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
            if (_maze.MazePack.Map[neighbour.x, neighbour.z] == 1)
                continue;
            //TODO - вынести это потом в BorderHandler
            if (neighbour.x < 1 || neighbour.x >= _maze.MazePack.Width || neighbour.z < 1 
                || neighbour.z >= _maze.MazePack.Depth)
                continue;
            if (_closedMapList.IsClodes(neighbour))
                continue;
            float g = ScoresHandler.CalculateGValue(thisNode.location.ToVector(), neighbour.ToVector(), thisNode.G);
            float h = ScoresHandler.CalculateHValue(neighbour.ToVector(), _goalNode.location.ToVector());
            float f = ScoresHandler.CalculateFValue();
            PathScores scores = _scoresHandler.GetScoresDataAStar(f,g,h);
            ScoresHandler.ClearCache();
            Vector3 intermediatePos = new Vector3(neighbour.x * _data.Scale, 0, neighbour.z * _data.Scale);
            GameObject pathBlock = _marksCreater.CreateIntermediate(intermediatePos);
            _mazePathMarkerHandler.SetText(pathBlock, _scoresHandler.GetScoresDataAStar(f,g,h));
        }
    }

    //TODO - это тоже надо вынести в отдельный сервис Handler
    private void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
        {
            Destroy(m);
        }
    }
}