using System;
using System.Reflection;

namespace Lesson_4.Lesson4_GameSystem.Scripts.DIFramework
{
    public static class DependencyInjector
    {
        public static void Inject(object target, ServiceLocator locator)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic |
                BindingFlags.FlattenHierarchy
                );

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(InjectAttribute)))
                {
                    InvokeConstruct(method, target, locator);
                }

                //TODO - здесь осуществлялся поиск по имени
                /*if (method.Name == "Construct")
                {
                    InvokeConstruct(method, target);
                }*/
            }
        }

        private static void InvokeConstruct(MethodInfo method, object target, ServiceLocator locator)
        {
            ParameterInfo[] parametrs = method.GetParameters();
            int count = parametrs.Length;
            object[] args = new object[count];

            for (int i = 0; i < count; i++)
            {
                ParameterInfo parametr = parametrs[i];
                Type type = parametr.ParameterType;
                object service = locator.GetService(type);
                args[i] = service;
            }

            method.Invoke(target, args);
        }
    }
}