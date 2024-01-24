class InstantiateMazeFactory : IMazeMarkFactory
{
    public IMazeMarkCreaterService LoadMarkCreaterService()
    {
        return new IMazeLoader();
    }
}