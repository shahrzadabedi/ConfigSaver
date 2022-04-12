namespace ConfigSaver
{
    public interface ISerializer
    {
        string  Serialize(object input);
        T Deserialize<T>(string input);
    }
}