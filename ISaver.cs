using System.Threading.Tasks;

namespace ConfigSaver
{
    public interface ISaver
    {
        Task WriteAsync(string key,string value);
        Task <string> ReadAsync(string key);
        void Write(string key, string value);
        string Read(string key);
    }
}