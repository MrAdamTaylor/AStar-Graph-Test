using System.Collections.Generic;

namespace Modules.MazeGenerator.Data
{
    public static class Directions
    {
        //TODO - здесь можно добавить статичное поле, так как к это лишь информация о том, куда будет шагать алгоритм
        public static List<MapLocationStruct> directions = new List<MapLocationStruct>()
        {
            new MapLocationStruct(1,0),
            new MapLocationStruct(0,1),
            new MapLocationStruct(-1,0),
            new MapLocationStruct(0,-1)
        };
    }
}