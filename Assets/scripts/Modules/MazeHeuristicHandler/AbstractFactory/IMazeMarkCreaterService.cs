using UnityEngine;

public interface IMazeMarkCreaterService
{
    GameObject CreateStartMarker();
    GameObject CreateFinishMarker();
    GameObject CreateIntermediateMarker();
}