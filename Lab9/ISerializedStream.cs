using System.IO;

namespace Lab8
{
    internal interface ISerializedStream
    {
        T Load<T>(StreamReader sr) where T : new();
        void Save<T>(T ob, StreamWriter sw);
    }
}