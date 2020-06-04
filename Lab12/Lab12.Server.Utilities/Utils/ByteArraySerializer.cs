using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.Utilities.Utils
{
    public static class ByteArraySerializer
    {
        public static byte[] Serialize<T>(this T m)
        {
            using (var memStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memStream, m);

                return memStream.ToArray();
            }
        }

        public static T Deserialize<T>(this byte[] byteArray)
        {
            using (var memStream = new MemoryStream(byteArray))
            {
                return (T)new BinaryFormatter().Deserialize(memStream);
            }
        }
    }
}
