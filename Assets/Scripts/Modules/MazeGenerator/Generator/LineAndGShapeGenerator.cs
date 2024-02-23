using Modules.MazeDataHandler;
using Modules.MazeGenerator.Data;

namespace Modules.MazeGenerator.Generator
{
    class LineAndGShapeGenerator : IGenerate
    {
        private MazeData _mazeData;

        public LineAndGShapeGenerator(MazeData mazeData)
        {
            _mazeData = mazeData;
        }
        public void Generate()
        {
            GenerateLines(5);  // Добавим 5 линий небольших размеров
            GenerateGShapes(3);  // Добавим 3 Г-образных препятствия
            PackData();
        }
        
        
        private void GenerateLines(int numLines)
        {
            for (int i = 0; i < numLines; i++)
            {
                int startX = UnityEngine.Random.Range(1, _mazeData.Width - 1);
                int startZ = UnityEngine.Random.Range(1, _mazeData.Depth - 1);

                int length = UnityEngine.Random.Range(3, 8);

                for (int j = 0; j < length; j++)
                {
                    int currentX = startX + j;
                    int currentZ = startZ;

                    if (currentX >= 1 && currentX < _mazeData.Width - 1 && currentZ >= 1 && currentZ < _mazeData.Depth - 1)
                    {
                        _mazeData.Map[currentX, currentZ] = 0;
                    }
                }
            }
        }

        private void GenerateGShapes(int numShapes)
        {
            for (int i = 0; i < numShapes; i++)
            {
                int startX = UnityEngine.Random.Range(1, _mazeData.Width - 3);
                int startZ = UnityEngine.Random.Range(1, _mazeData.Depth - 3);

                for (int x = startX; x < startX + 3; x++)
                {
                    for (int z = startZ; z < startZ + 3; z++)
                    {
                        if (x >= 1 && x < _mazeData.Width - 1 && z >= 1 && z < _mazeData.Depth - 1)
                        {
                            _mazeData.Map[x, z] = 0;
                        }
                    }
                }
            }
        }

        private void PackData()
        {
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}