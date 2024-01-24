namespace Modules.MazeGenerator
{
    public static class NeighboursHandler
    {
        public static int CountSquareNeighbours(int x, int z, MazeData mazeData)
        {
            int count = 0;
            if (x <= 0 || x >= mazeData.Width - 1 || z <= 0 || z >= mazeData.Depth - 1) return 5;
            if (mazeData.Map[x - 1, z] == 0) count++;
            if (mazeData.Map[x + 1, z] == 0) count++;
            if (mazeData.Map[x, z + 1] == 0) count++;
            if (mazeData.Map[x, z - 1] == 0) count++;
            return count;
        }
    
    }
}