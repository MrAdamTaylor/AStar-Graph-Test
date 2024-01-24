using System.Collections;
using System.Collections.Generic;
using Modules.MazeGenerator;
using UnityEngine;

public class MazePathStarter : MonoBehaviour
{
    [SerializeField] private MarksCreater _marksCreater;
    [SerializeField] private MazeGenerator _maze;

    public Material closedMaterial;
    public Material openMaterial;
    private bool _done = false;
    private MazeData _data;
    private List<MapLocationStruct> _uselocations;
    
    private MazePathMarker _goalNode;
    private MazePathMarker _startNode;
    void Start()
    {
        _data = _maze.mazePack;
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
        CreatePlaceForPathfinding();
        _uselocations.Shuffle();
        Vector3 startPos = new Vector3(_uselocations[0].x * _data.Scale, 0, _uselocations[0].z * _data.Scale);
        _startNode = new MazePathMarker(
            new MapLocationStruct(_uselocations[0].x * _data.Scale,_uselocations[0].z * _data.Scale),
            0, 0, 0, _marksCreater.CreateStart(startPos), null
        );
        Vector3 finishPos = new Vector3(_uselocations[1].x * _data.Scale, 0, _uselocations[1].z * _data.Scale);
        _goalNode = new MazePathMarker(
            new MapLocationStruct(_uselocations[1].x * _data.Scale,_uselocations[1].z * _data.Scale),
            0, 0, 0, _marksCreater.CreateFinish(finishPos), null
        );
    }

    private void CreatePlaceForPathfinding()
    {
        _uselocations = new List<MapLocationStruct>();
        for (int z = 1; z < _data.Depth - 1; z++)
        {
            for (int x = 1; x < _data.Width - 1; x++)
            {
                if (_data.Map[x, z] != 1)
                {
                    _uselocations.Add(new MapLocationStruct(x, z));
                }
            }
        }
    }

    private void RemoveAllMarkers()
    {
        
    }
}
