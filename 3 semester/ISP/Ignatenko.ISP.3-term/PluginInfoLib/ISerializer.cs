using System.IO;

namespace PluginInfoLib
{
    public interface ISerializer<T>
    {
        void Serialize(Stream stream, T data);

        T Deserialize(Stream stream);
    }
}
