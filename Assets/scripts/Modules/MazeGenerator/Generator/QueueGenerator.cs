using System.Collections.Generic;

namespace Modules.MazeGenerator
{
    public class QueueGenerator : IGenerate
    {
        private MazeData _mazeData;
        private Directions _directions;
        public QueueGenerator(MazeData mazeData)
        {
            _mazeData = mazeData;
            _directions = new Directions(mazeData.Map);
        }

        public void Generate()
        {
            Stack<MapLocationStruct> stack = new Stack<MapLocationStruct>();
            stack.Push(new MapLocationStruct(MazeConstants.XCord,MazeConstants.YCord));

            while (stack.Count > 0)
            {
                MapLocationStruct current = stack.Pop();

                if (NeighboursHandler.CountSquareNeighbours(current.x, current.z, _mazeData) >= 2)
                    continue;

                _directions.map[current.x, current.z] = 0;  // Прорубаем путь

                _directions.directions.Shuffle();

                foreach (var direction in _directions.directions)
                {
                    MapLocationStruct next = current + direction;

                    // Проверяем границы
                    if (next.x <= 0 || next.x >= _mazeData.Width - 1 || next.z <= 0 || next.z >= _mazeData.Depth - 1)
                        continue;

                    // Проверяем, не была ли эта точка уже посещена
                    if (_mazeData.Map[next.x, next.z] == 0)
                        continue;

                    stack.Push(next);
                }
            }
        }
    }
}