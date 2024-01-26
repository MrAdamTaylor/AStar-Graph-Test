using System.Collections.Generic;
using Lesson_4.Lesson4_GameSystem.Scripts.DIFramework;

namespace Modules.MazeGenerator
{
    public class QueueGenerator : IGenerate
    {
        private MazeData _mazeData;
        public QueueGenerator(MazeData mazeData)
        {
            _mazeData = mazeData;
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

                _mazeData.Map[current.x, current.z] = 0;  // Прорубаем путь

                Directions.directions.Shuffle();

                foreach (var direction in Directions.directions)
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
            PackData();
        }

        private void PackData()
        {
            //MazeServiceLocator.Instance.BindMazeData(typeof(byte[,]), _directions.map);
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}