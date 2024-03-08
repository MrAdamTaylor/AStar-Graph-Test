using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Generater : MonoBehaviour
{
    public int _width = 30;
    public int _depth = 30;
    public int _scale = 5;

    private byte[,] _map;

    public void Start()
    {
        _map = new byte[_width, _depth];
        for (int z = 0; z < _depth; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                _map[x, z] = 1;
            }
        }

        CustomGenerate();
        RandomPoints();
        DrawMap(_map);
    }

    private void RandomPoints()
    {
       
    }

    private void CustomGenerate()
    {
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                if (i <= 0 || i >= _width - 1 || j <= 0 || j >= _depth - 1)
                    continue;

                _map[i, j] = 0;
            }
        }
    }

    public void DrawMap(byte[,] map)
    {
        var parentObject = new GameObject("Maze");
        for (int z = 0; z < _map.GetLength(1); z++)
        {
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                if (_map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * _scale, 0, z * _scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(_scale, _scale, _scale);
                    wall.transform.position = pos;
                    wall.transform.parent = parentObject.transform;
                }
            }
        }
    }
}
