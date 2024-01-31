using Modules.Extensions;

namespace LegacyCode
{
    public class Recursive : Maze
    {
        #region С Рекурсией

        public override void Generate()
        {
            Generate(5, 5);
        }

        void Generate(int x, int z)
        {
            if (CountSquareNeighbours(x, z) >= 2) return;
            map[x, z] = 0;

            directions.Shuffle();

            Generate(x + directions[0].x, z + directions[0].z);
            Generate(x + directions[1].x, z + directions[1].z);
            Generate(x + directions[2].x, z + directions[2].z);
            Generate(x + directions[3].x, z + directions[3].z);
        }
    
        #endregion

        #region Без рекурсии

        /*public override void Generate()
    {
        Stack<MapLocationStruct> stack = new Stack<MapLocationStruct>();
        stack.Push(new MapLocationStruct(5, 5));

        while (stack.Count > 0)
        {
            MapLocationStruct current = stack.Pop();

            if (CountSquareNeighbours(current.x, current.z) >= 2)
                continue;

            map[current.x, current.z] = 0;  // Прорубаем путь

            directions.Shuffle();

            foreach (var direction in directions)
            {
                MapLocationStruct next = current + direction;

                // Проверяем границы
                if (next.x <= 0 || next.x >= width - 1 || next.z <= 0 || next.z >= depth - 1)
                    continue;

                // Проверяем, не была ли эта точка уже посещена
                if (map[next.x, next.z] == 0)
                    continue;

                stack.Push(next);
            }
        }
    }*/
    
        #endregion

    }
}
