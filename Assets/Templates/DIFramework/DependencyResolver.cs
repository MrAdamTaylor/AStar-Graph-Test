using UnityEngine;

namespace Lesson_4.Lesson4_GameSystem.Scripts.DIFramework
{
    public class DependencyResolver : MonoBehaviour
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        
        private void Start()
        {
            GameObject[] gameObjects = this.gameObject.scene.GetRootGameObjects();
            foreach (var go in gameObjects)
            {
                this.Inject(go.transform);
            }
        }

        private void Inject(Transform goTransform)
        {
            var targets = goTransform.GetComponents<MonoBehaviour>();
            foreach (var target in targets)
            {
                DependencyInjector.Inject(target, _serviceLocator);
            }

            foreach (Transform child in goTransform)
            {
                this.Inject(child);
            }
        }

        //TODO - этот метод нужен, если надо иметь зависимость от MonoBehaviour
        /*[SerializeField] private MonoBehaviour[] _targets;
    
    private void Start()
    {
        foreach (var target in this._targets)
        {
            DependencyInjector.Inject(target);
        }
    }*/
    }
}
