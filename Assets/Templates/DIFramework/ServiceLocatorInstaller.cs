using UnityEngine;

namespace Lesson_4.Lesson4_GameSystem.Scripts.DIFramework
{
    public class ServiceLocatorInstaller : MonoBehaviour
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        
        /*[SerializeField]
        private KeyboardInput _moveInput;*/

        /*[SerializeField]
        private Player _player;*/

        private void Awake()
        {
            //this._serviceLocator.BindService(typeof(Player), this._player);
            //this._serviceLocator.BindService(typeof(IInputSystem), this._moveInput);
        }
    }
}