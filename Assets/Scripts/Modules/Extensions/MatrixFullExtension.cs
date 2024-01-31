namespace Modules.Extensions
{
    public static class MatrixFullExtension
    {
        public static byte[,] FullOneMatrix(this byte[,] matrix, int width, int depth)
        {
            matrix = new byte[width, depth];
            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[x, z] = 1;     //1 = wall  0 = corridor
                }
            }
            return matrix;
        }
    }
}