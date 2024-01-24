using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPathAStar : MonoBehaviour
{
    //TODO - лабиринт Maze надо будет заинджектить!
    public Maze maze;
    public Material closedMaterial;
    public Material openMaterial;

    private List<MazePathMarker> open = new List<MazePathMarker>();
    private List<MazePathMarker> closed = new List<MazePathMarker>();

    #region Маркеры, которые будут ставится
    
        public GameObject start;
        public GameObject end;
        public GameObject pathP;
    
    #endregion
    
    private MazePathMarker _goalNode;
    private MazePathMarker _startNode;

    private MazePathMarker _lastPos;
    private bool _done = false;

    void BeginSearch()
    {
        _done = false;
        RemoveAllMarkers();

        List<MapLocationStruct> locations = new List<MapLocationStruct>();
        for (int z = 1; z < maze.depth - 1; z++)
            for (int x = 1; x < maze.width - 1; x++)
            {
                if (maze.map[x, z] != 1)
                {
                    //TODO 
                    locations.Add(new MapLocationStruct(x,z));
                }

            }
        
        locations.Shuffle();

        Vector3 startLocation = new Vector3(locations[0].x * maze.scale, 0, locations[0].z * maze.scale);
        _startNode = new MazePathMarker(new MapLocationStruct(locations[0].x * maze.scale, locations[0].z * maze.scale), 
            0, 0, 0, Instantiate(start, startLocation, Quaternion.identity), null);

        Vector3 finishLocation = new Vector3(locations[1].x * maze.scale, 0, locations[1].z * maze.scale);
        _goalNode = new MazePathMarker(new MapLocationStruct(locations[1].x * maze.scale, locations[1].z * maze.scale), 
            0, 0, 0, Instantiate(end, finishLocation, Quaternion.identity), null);
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
    }
}
