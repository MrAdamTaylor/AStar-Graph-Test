
using UnityEngine;

public class FactoryTester : MonoBehaviour
{
    public void Start()
    {
        IMazeMarkFactory markFactory = new InstantiateMazeFactory();
        MazeMarkCreater markCreater = new MazeMarkCreater(markFactory);
    }
}
