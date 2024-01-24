public interface IMazeMarkFactory 
{
    public IMazeMarkCreaterService LoadMarkCreaterService()
    {
        throw new System.Exception("Не установлен сервис загрузки в фабрике маркеров");
    }
}