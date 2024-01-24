using System.Collections.Generic;

namespace Modules.MazeGenerator
{
    public class Directions
    {
        public List<MapLocationStruct> directions = new List<MapLocationStruct>()
        {
            new MapLocationStruct(1,0),
            new MapLocationStruct(0,1),
            new MapLocationStruct(-1,0),
            new MapLocationStruct(0,-1)
        };

        public byte[,] map;

        public Directions(byte[,] bytes)
        {
            map = bytes;
        }
    }
}