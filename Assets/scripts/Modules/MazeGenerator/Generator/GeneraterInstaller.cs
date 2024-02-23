using Modules.MazeGenerator.Data;

namespace Modules.MazeGenerator.Generator
{
    public class GeneraterInstaller
    {
        private IGenerate _generate;
        
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

        public IGenerate GetGenerator(GeneratorType type, MazeData mazeData)
        {
            switch (type)
            {
                case GeneratorType.Maze:
                    _generate = new QueueGenerator(mazeData);
                    break;
                case GeneratorType.Points:
                    _generate = new EdgeFillAndRandomGenerator(mazeData);
                    break;
                case GeneratorType.SomwObjects:
                    _generate = new LineAndGShapeGenerator(mazeData);
                    break;
                case GeneratorType.NonMaze:
                    _generate = new NonMazeGenerate(mazeData);
                    break;
            }

            return _generate;
        }
    }
}