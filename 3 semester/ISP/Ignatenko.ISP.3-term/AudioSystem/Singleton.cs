using System;
using System.Reflection;

namespace AudioSystem
{
    abstract class Singleton<T>
    {
// ReSharper disable StaticFieldInGenericType
        private static readonly ConstructorInfo Constructor =
            typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                                      new Type[0], null); //неявно требую NonPublic конструктор без параметров
// ReSharper restore StaticFieldInGenericType

        private static readonly Lazy<T> LazyInstance = new Lazy<T>(() => (T)Constructor.Invoke(null));

        public static T Instance { get { return LazyInstance.Value; } }
    }
}
