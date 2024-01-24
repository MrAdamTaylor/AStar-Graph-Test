namespace Modules.MazeGenerator
{
    public class DrawerInstaller
    {
    
    
        public IMazeDrawer GetDrawer(MazeData mazeData)
        {
            IMazeDrawer mazeDrawer = new MazeDrawer(mazeData);
            return mazeDrawer;
        }
    }
}