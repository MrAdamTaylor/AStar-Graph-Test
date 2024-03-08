using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenes.TestScenes.Probability_and_Buffers.EnterpriceLogic
{
    public static class InterfaceHandler
    {
        public static IEnumerable<T> GetInterfaceImplementations<T>()
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
}