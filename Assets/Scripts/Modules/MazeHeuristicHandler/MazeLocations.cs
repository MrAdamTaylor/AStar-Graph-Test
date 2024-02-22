using System.Collections.Generic;
using Modules.Extensions;
using Modules.MazeGenerator.Data;

namespace Modules.MazeHeuristicHandler
{
    public class MazeLocations
    {
        public List<MapLocationStruct> UsefulLocation;

        public MazeLocations(MazeData data)
        {
            UsefulLocation = new List<MapLocationStruct>();
            for (int z = 0; z < data.Depth; ++z)
            {
                for (int x = 0; x < data.Width; ++x)
                {
                    if (data.Map[x, z] != 1)
                    {
                        UsefulLocation.Add(new MapLocationStruct(x,z));
                    }
                }
            }
        }
    
        /*public MazeLocations(byte[,] mapData, MazeData data)
    {
        UsefulLocation = new List<MapLocationStruct>();
        for (int z = 1; z < data.Depth - 1; z++)
        {
            for (int x = 1; x < data.Width - 1; x++)
            {
                if (mapData[x, z] != 1)
                {
                    UsefulLocation.Add(new MapLocationStruct(x,z));
                }
            }
        }
    }*/

        public void Shuffle()
        {
            UsefulLocation.Shuffle();
        }

        public int GetXByIndex(int index)
        {
            return UsefulLocation[index].x;
        }

        public int GetZByIndex(int index)
        {
            return UsefulLocation[index].z;
        }
    }
}
