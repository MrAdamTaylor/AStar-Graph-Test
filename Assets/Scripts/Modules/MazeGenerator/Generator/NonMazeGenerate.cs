using Modules.MazeDataHandler;
using Modules.MazeGenerator.Data;
using Unity.VisualScripting;

namespace Modules.MazeGenerator.Generator
{
    class NonMazeGenerate : IGenerate
    {
        
        private MazeData _mazeData;

        public NonMazeGenerate(MazeData mazeData)
        {
            _mazeData = mazeData;
        }

        public void Generate()
        {
            GenerateNonMaze();
            GetMapData();
        }

        private void GenerateNonMaze()
        {
            for (int i = 0; i < _mazeData.Map.GetLength(0); i++)
            {
                for (int j = 0; j < _mazeData.Map.GetLength(1); j++)
                {
                    if (i <= 0 || i >= _mazeData.Width - 1 || j <= 0 || j >= _mazeData.Depth - 1)
                        continue;
                    
                    _mazeData.Map[i, j] = 0;
                }
            }
        }

        private void GetMapData()
        {
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}