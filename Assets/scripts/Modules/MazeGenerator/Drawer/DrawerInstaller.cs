namespace Modules.MazeGenerator.Drawer
{
    public class DrawerInstaller
    {
        public IMazeDrawer GetDrawer()
        {
            IMazeDrawer mazeDrawer = new MazeDrawer();
            return mazeDrawer;
        }
    }
}