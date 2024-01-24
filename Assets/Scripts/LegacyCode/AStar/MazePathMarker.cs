using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePathMarker
{
    public MapLocationStruct location;
    public float G;
    public float H;
    public float F;
    public GameObject marker;
    public MazePathMarker parent;

    public MazePathMarker(MapLocationStruct l, float g, float h, float f, GameObject marker, MazePathMarker p)
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
            return location.Equals(((MazePathMarker)obj).location);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
