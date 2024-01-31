using Modules.MazeDataHandler;
using Modules.MazeGenerator.Data;
using UnityEngine;

namespace Modules.MazeGenerator.Drawer
{
    public class MazeDrawer : IMazeDrawer
    {
        private MazeData _mazeData;

        public void DrawMap()
        {
            _mazeData = (MazeData)MazeServiceLocator.Instance.GetData(typeof(MazeData));
            var parentObject = new GameObject("Maze");
            for (int z = 0; z < _mazeData.Depth; z++)
            {
                for (int x = 0; x < _mazeData.Width; x++)
                {
                    if (_mazeData.Map[x, z] == 1)
                    {
                        Vector3 pos = new Vector3(x * _mazeData.Scale, 0, z * _mazeData.Scale);
                        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        wall.transform.localScale = new Vector3(_mazeData.Scale, _mazeData.Scale, _mazeData.Scale);
                        wall.transform.position = pos;
                        //TODO - его нельзя ставить раньше
                        wall.transform.parent = parentObject.transform;
                    }
                }
            }
            PackMapData();
        }

        private void PackMapData()
        {
            MazeServiceLocator.Instance.BindMazeData(typeof(MazeData), _mazeData);
        }
    }
}