
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
        public MazeData MazePack;

        void Awake()
        {
            MazePack = FullMazeData(_width, _depth, _map, _scale);
            GeneraterInstaller generaterIinstaller = new GeneraterInstaller();
            DrawerInstaller drawerInstaller = new DrawerInstaller();
            IGenerate generater = generaterIinstaller.GetGenerator(_isOptimization,MazePack);
            IMazeDrawer mazeDrawer = drawerInstaller.GetDrawer();
            generater.Generate();
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