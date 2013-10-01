using System.IO;

namespace Lab5.Plugins
{
    public interface ISerializer<T>
    {
        void Serialize(Stream stream, T data);

        T Deserialize(Stream stream);
    }
}
