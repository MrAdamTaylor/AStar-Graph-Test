using UnityEngine;

public class MarksCreater :  MonoBehaviour, IMarksCreater
{
    private MazeMarkCreater _markCreater;
    
    public void Start()
    {
        IMazeMarkFactory markFactory = new InstantiateMazeFactory();
        //MazeMarkCreater markCreater = new MazeMarkCreater(markFactory);
        _markCreater = new MazeMarkCreater(markFactory);
    }

    //TODO - я думаю в будущем этот вопрос инджекцией решить
    public GameObject CreateStart(Vector3 vec)
    {
        GameObject start = Instantiate(_markCreater.CreateStart(), vec, Quaternion.identity);
        return start;
    }

    public GameObject CreateFinish(Vector3 vec)
    {
        GameObject finish = Instantiate(_markCreater.CreateFinish(), vec, Quaternion.identity);
        return finish;
    }

    public GameObject CreateIntermediate(Vector3 vec)
    {
        GameObject intermediate = Instantiate(_markCreater.CreateIntermediate(), vec, Quaternion.identity);
        return intermediate;
    }

}