using System;
using JetBrains.Annotations;

namespace Lesson_4.Lesson4_GameSystem.Scripts.DIFramework
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public class InjectAttribute : Attribute
    {
        
    }
}