using System.Web.Script.Serialization;
using ServiceStack.Text;

namespace System
{
    public interface ISerializer
    {
        T Deserialize<T>(string input);
        string Serialize(object obj);
    }

    public class SerializerCollection
    {
        private static ISerializer _jsonSerializer;
        public static ISerializer JsonSerializer
        {
            get
            {
                if (null == _jsonSerializer)
                {
                    _jsonSerializer = new JsonSerializer();
                }
                return _jsonSerializer;
            }
        }

        private static ISerializer _frameJsonSerializer;

        public static ISerializer FrameJsonSerializer
        {
            get
            {
                if (null == _frameJsonSerializer)
                {
                    _frameJsonSerializer = new FrameJsonSerializer();
                }
                return _frameJsonSerializer;
            }
        }
    }

    internal class JsonSerializer : JavaScriptSerializer, ISerializer
    {

    }

    internal class FrameJsonSerializer : ISerializer
    {
        public T Deserialize<T>(string input)
        {
            return TypeSerializer.DeserializeFromString<T>(input);
        }

        public string Serialize(object obj)
        {
            return TypeSerializer.SerializeToString<object>(obj);
        }
    }
}