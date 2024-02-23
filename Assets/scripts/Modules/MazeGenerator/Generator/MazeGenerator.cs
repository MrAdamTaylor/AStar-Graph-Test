using Modules.Extensions;
using Modules.MazeDataHandler;
using Modules.MazeGenerator.Data;
using Modules.MazeGenerator.Drawer;
using UnityEngine;

public enum GeneratorType
{
     Maze,
     NonMaze,
     Points,
     SomwObjects
}

namespace Modules.MazeGenerator.Generator
{
    //TODO - временный костыль, пока ещё нет инджекций
    [DefaultExecutionOrder(-500)]
    public class MazeGenerator : MonoBehaviour
    {
        [Header("Внимание, при постановке этой галочки будет только лабиринт")]
        [SerializeField] private bool _isOptimization;
        //[SerializeField] private bool _isMaze = true;
        [SerializeField] private GeneratorType _generatorType;
        [SerializeField] private int _width = 30;
        [SerializeField] private int _depth = 30;
        [SerializeField] private int _scale = 5;
        private byte[,] _map;
        public MazeData MazePack;

        private IGenerate _generater;

        void Awake()
        {
            MazePack = FullMazeData(_width, _depth, _map, _scale);
            GeneraterInstaller generaterIinstaller = new GeneraterInstaller();
            DrawerInstaller drawerInstaller = new DrawerInstaller();
            IMazeDrawer mazeDrawer = drawerInstaller.GetDrawer();
            if (_isOptimization)
            {
                _generater = generaterIinstaller.GetGenerator(_isOptimization,MazePack);
            }
            else
            {
                _generater = generaterIinstaller.GetGenerator(_generatorType, MazePack);
            }
            _generater.Generate();
            mazeDrawer.DrawMap();
            MazePack = (MazeData)MazeServiceLocator.Instance.GetData(typeof(MazeData));
        }

        private MazeData FullMazeData(int width, int depth, byte[,] bytes, int scale)
        {
            MazeData data = new MazeData();
            data.Depth = depth;
            data.Width = width;
            bytes = bytes.FullOneMatrix(width, depth);
            data.Map = bytes;
            data.Scale = scale;
            return data;
        }
    }
}