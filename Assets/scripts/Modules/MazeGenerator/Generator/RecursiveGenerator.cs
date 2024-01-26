namespace Modules.MazeGenerator
{
    public class RecursiveGenerator : IGenerate
    {
        private MazeData _mazeData;

        public RecursiveGenerator(MazeData mazeData)
        {
            _mazeData = mazeData;
        }

        public void Generate()
        {
            RecusiveGenerate(MazeConstants.XCord,MazeConstants.YCord);
            GetMapData();
        }

        public void RecusiveGenerate(int x, int z)
        {
            if (NeighboursHandler.CountSquareNeighbours(x, z, _mazeData) >= 2) return;
                _mazeData.Map[x, z] = 0;
            //_directions.map[x, z] = 0;

            Directions.directions.Shuffle();

            RecusiveGenerate(x + Directions.directions[0].x, z + Directions.directions[0].z);
            RecusiveGenerate(x + Directions.directions[1].x, z + Directions.directions[1].z);
            RecusiveGenerate(x + Directions.directions[2].x, z + Directions.directions[2].z);
            RecusiveGenerate(x + Directions.directions[3].x, z + Directions.directions[3].z);
        }
        
        private void GetMapData()
        {
            //MazeServiceLocator.Instance.BindMazeData(typeof(byte[,]), _directions.map);
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}