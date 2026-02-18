namespace ContextCompiler.Abstractions.Configuration
{
    public interface ICtxcConfigSerializer
    {
        ICtxcConfig Deserialize(string json);
        string Serialize(ICtxcConfig config);
    }
}
