using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ConfigSaver
{
    public class ConfigSaver
    {
        private IEncoder Encoder;
        private ISerializer Serializer;
        private ISaver Saver;
        public ConfigSaver(IEncoder encoder, ISerializer serializer,ISaver saver)
        {
            this.Encoder = encoder;
            this.Serializer = serializer;
            this.Saver = saver;
        }
        public async Task  SaveConfigAsync(string key,object value) 
        {
            var se = Serializer.Serialize(value);
            var en = Encoder.Encode(se);
           await Saver.WriteAsync(key, en);
        }
        public void SaveConfig(string key, object value)
        {
            var se = Serializer.Serialize(value);
            var en = Encoder.Encode(se);
            Saver.Write(key, en);
        }
        public async Task<T> ReadConfigAsync<T>(string key)
        {
            var value = await Saver.ReadAsync(key);
            var en = Encoder.Decode(value);
            return Serializer.Deserialize<T>(en);
        }
        public T ReadConfig<T>(string key)
        {
            var value =  Saver.Read(key);
            var en = Encoder.Decode(value);
            return Serializer.Deserialize<T>(en);
        }
    }
}