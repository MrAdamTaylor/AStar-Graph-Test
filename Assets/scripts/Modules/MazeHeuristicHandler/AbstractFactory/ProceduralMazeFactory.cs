namespace Modules.MazeHeuristicHandler.AbstractFactory
{
    public class ProceduralMazeFactory : IMazeMarkFactory
    {
        public IMazeMarkCreaterService LoadMarkCreaterService()
        {
            return new IMazeProceduralCreater();
        }
    }
}