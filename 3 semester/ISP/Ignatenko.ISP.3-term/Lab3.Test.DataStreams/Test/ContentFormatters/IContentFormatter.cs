using System;

namespace Test.ContentFormatters
{
    /// <summary>
    /// Сохраняет и загружает объект.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContentFormatter<T> : IDisposable
    {
        SavingFormat Format { get; }

        void Save(T data);

        T Load();
    }
}