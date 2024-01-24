using UnityEngine;

namespace Modules.MazeGenerator
{
    public class MazeDrawer : IMazeDrawer
    {
        private MazeData _mazeData;
        public MazeDrawer(MazeData mazeData)
        {
            _mazeData = mazeData;
        }

        public void DrawMap()
        {
            var parentObject = new GameObject("Maze");
            for (int z = 0; z < _mazeData.Depth; z++)
            for (int x = 0; x < _mazeData.Width; x++)
            {
                if (_mazeData.Map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * _mazeData.Scale, 0, z * _mazeData.Scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.parent = parentObject.transform;
                    wall.transform.localScale = new Vector3(_mazeData.Scale, _mazeData.Scale, _mazeData.Scale);
                    wall.transform.position = pos;
                }
            }
        }
    }
}