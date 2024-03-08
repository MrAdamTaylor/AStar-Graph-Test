using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImplementationGetter : MonoBehaviour
{
    void Start()
    {
        List<IMyInterface> implementations = GetInterfaceImplementations<IMyInterface>().ToList();

        foreach (var implementation in implementations)
        {
            implementation.MyMethod();
        }
    }

    static IEnumerable<T> GetInterfaceImplementations<T>()
    {
        Type interfaceType = typeof(T);

        // Получаем все типы в текущей сцене
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes());

        foreach (var type in types)
        {
            // Проверяем, является ли тип классом и реализует ли интерфейс
            if (type.IsClass && interfaceType.IsAssignableFrom(type))
            {
                // Создаем экземпляр класса и возвращаем его
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}

public interface IMyInterface
{
    void MyMethod();
}

public class MyClass1 : MonoBehaviour, IMyInterface
{
    public void MyMethod()
    {
        Debug.Log("MyClass1");
    }
}

public class MyClass2 : MonoBehaviour, IMyInterface
{
    public void MyMethod()
    {
        Debug.Log("MyClass2");
    }
}

