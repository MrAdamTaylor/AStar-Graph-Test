
using System;
using UnityEngine;

namespace Modules.MazeGenerator
{
    //TODO - временный костыль, пока ещё нет инджекций
    [DefaultExecutionOrder(-500)]
    public class MazeGenerator : MonoBehaviour
    {
        [SerializeField] private bool _isOptimization;
        [SerializeField] private int _width = 30;
        [SerializeField] private int _depth = 30;
        [SerializeField] private int _scale = 5;
        private byte[,] _map;
        [NonSerialized]public MazeData MazePack;
        private MazeServiceLocator _serviceLocator;
        
        void Start()
        {
            MazePack = FullMazeData(_width, _depth, _map, _scale);
            GeneraterInstaller generaterIinstaller = new GeneraterInstaller();
            DrawerInstaller drawerInstaller = new DrawerInstaller();
            IGenerate generater = generaterIinstaller.GetGenerator(_isOptimization,MazePack);
            IMazeDrawer mazeDrawer = drawerInstaller.GetDrawer(MazePack);
            generater.Generate();
            mazeDrawer.DrawMap();
        }

        private MazeData FullMazeData(int width, int depth, byte[,] bytes, int scale)
        {
            MazeData data = new MazeData();
            data.Depth = depth;
            data.Width = width;
            InitializeMap(ref bytes, width, depth);
            data.Map = bytes;
            data.Scale = scale;
            return data;
        }

        private void InitializeMap(ref byte[,] bytes, int width, int depth)
        {
            bytes = new byte[width,depth];
            for (int z = 0; z < depth; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    bytes[x, z] = 1;     //1 = wall  0 = corridor
                }
            }
        }
    }
}