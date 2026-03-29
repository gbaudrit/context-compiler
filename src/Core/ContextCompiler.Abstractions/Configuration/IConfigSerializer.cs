using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Configuration
{
    public interface IConfigSerializer
    {
        IRootConfigSection Deserialize(string json);
        string Serialize(IRootConfigSection config);
    }
}
