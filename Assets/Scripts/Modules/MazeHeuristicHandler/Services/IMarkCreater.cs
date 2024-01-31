using UnityEngine;

//TODO - пока это избыточный интерфейс, но планируется инъекция
namespace Modules.MazeHeuristicHandler.Services
{
    public interface IMarksCreater
    {
        public GameObject CreateStart(Vector3 vec);
        public GameObject CreateFinish(Vector3 vec);
        public GameObject CreateIntermediate(Vector3 vec);
    }
}