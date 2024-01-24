namespace Modules.MazeGenerator
{
    public class RecursiveGenerator : IGenerate
    {
        private Directions _directions;
        private MazeData _mazeData;

        public RecursiveGenerator(MazeData mazeData)
        {
            _directions = new Directions(mazeData.Map);
            _mazeData = mazeData;
        }

        public void Generate()
        {
            RecusiveGenerate(MazeConstants.XCord,MazeConstants.YCord);
        }

        public void RecusiveGenerate(int x, int z)
        {
            if (NeighboursHandler.CountSquareNeighbours(x, z, _mazeData) >= 2) return;
            _mazeData.Map[x, z] = 0;
            _directions.map[x, z] = 0;

            _directions.directions.Shuffle();

            RecusiveGenerate(x + _directions.directions[0].x, z + _directions.directions[0].z);
            RecusiveGenerate(x + _directions.directions[1].x, z + _directions.directions[1].z);
            RecusiveGenerate(x + _directions.directions[2].x, z + _directions.directions[2].z);
            RecusiveGenerate(x + _directions.directions[3].x, z + _directions.directions[3].z);
        }
    }
}