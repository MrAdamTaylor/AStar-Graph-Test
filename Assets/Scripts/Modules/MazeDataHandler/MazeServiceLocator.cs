using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MazeServiceLocator
{
    [CanBeNull] private static MazeServiceLocator _instance;

    public static MazeServiceLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MazeServiceLocator();
            }
            return _instance;
        }
    }

    private readonly Dictionary<Type, object> _mazeDataBase = new();

    public object GetData(Type type)
    {
        return _mazeDataBase[type];
    }

    public void BindMazeData(Type type, object mazeData)
    {
        if (_mazeDataBase.ContainsKey(type))
        {
            _mazeDataBase[type] = mazeData;
        }
        else
        {
            _mazeDataBase.Add(type, mazeData);
        }

    }
}
