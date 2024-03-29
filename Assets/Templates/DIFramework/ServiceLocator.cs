using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_4.Lesson4_GameSystem.Scripts.DIFramework
{
    public  class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> services = new();

        public  object GetService(Type type)
        {
            return services[type];
        }

        public  T GetService<T>() where T : class
        {
            return services[typeof(T)] as T;
        }

        public void BindService(Type type, object service)
        {
            services.Add(type, service);
        }
    }
}
