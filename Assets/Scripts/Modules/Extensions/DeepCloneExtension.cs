using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Modules.Extensions
{
    public static class DeepCloneExtension 
    {
        static public T DeepCopy<T>(this T obj)
        {
            BinaryFormatter s = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                s.Serialize(ms, obj);
                ms.Position = 0;
                T t = (T)s.Deserialize(ms);

                return t;
            }
        }
    }
}
