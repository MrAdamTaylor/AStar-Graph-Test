using Modules.MazeDataHandler;
using Modules.MazeGenerator.Data;
using UnityEngine;

namespace Modules.MazeGenerator.Generator
{
    class EdgeFillAndRandomGenerator : IGenerate
    {
        private MazeData _mazeData;
        public EdgeFillAndRandomGenerator(MazeData mazeData)
        {
            _mazeData = mazeData;
        }
        public void Generate()
        {
            FillEdges();
            FillRandomCubes(0.8f);  // 20% случайных кубиков
            PackData();
        }
        
        private void FillEdges()
        {
            for (int i = 0; i < _mazeData.Map.GetLength(0); i++)
            {
                for (int j = 0; j < _mazeData.Map.GetLength(1); j++)
                {
                    if (i <= 0 || i >= _mazeData.Width - 1 || j <= 0 || j >= _mazeData.Depth - 1)
                        _mazeData.Map[i, j] = 1;
                }
            }
        }

        private void FillRandomCubes(float fillPercentage)
        {
            int totalCells = _mazeData.Width * _mazeData.Depth;
            int cellsToFill = Mathf.RoundToInt(totalCells * fillPercentage);

            for (int i = 0; i < cellsToFill; i++)
            {
                int randomX = UnityEngine.Random.Range(1, _mazeData.Width - 1);
                int randomZ = UnityEngine.Random.Range(1, _mazeData.Depth - 1);

                _mazeData.Map[randomX, randomZ] = 0;
            }
        }

        private void PackData()
        {
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}