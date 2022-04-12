using Newtonsoft.Json;

namespace ConfigSaver
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public string Serialize(object input)
        {
           return JsonConvert.SerializeObject(input);

        }
    }
}