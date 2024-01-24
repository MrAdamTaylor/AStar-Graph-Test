namespace Modules.MazeGenerator
{
    public class GeneraterInstaller
    {
        public IGenerate GetGenerator(bool isOptimization, MazeData mazeData)
        {
            if (isOptimization)
            {
                IGenerate generate = new RecursiveGenerator(mazeData);
                return generate;
            }
            else
            {
                IGenerate generate = new QueueGenerator(mazeData);
                return generate;
            }
        }
    }
}