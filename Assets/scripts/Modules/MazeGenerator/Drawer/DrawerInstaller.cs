namespace Modules.MazeGenerator
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