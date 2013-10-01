using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    abstract class Singleton<T>
    {
// ReSharper disable StaticFieldInGenericType
        private static readonly ConstructorInfo Constructor =
            typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                                      new Type[0], null); //конструктор без параметров
// ReSharper restore StaticFieldInGenericType

        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => (T)Constructor.Invoke(null));

        public static T Instance { get { return LazyInstance.Value; } }
    }
}
