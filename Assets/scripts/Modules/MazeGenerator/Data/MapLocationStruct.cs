using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapLocationStruct 
{
    public int x;
    public int z;

    public MapLocationStruct(int _x, int _z)
    {
        x = _x;
        z = _z;
    }

    public Vector2 ToVector()
    {
        return new Vector2(x, z);
    }

    public static MapLocationStruct operator +(MapLocationStruct a, MapLocationStruct b)
        => new MapLocationStruct(a.x + b.x, a.z + b.z);
    
    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            return false;
        else
            return x == ((MapLocationStruct)obj).x && z == ((MapLocationStruct)obj).z;
    }
}
