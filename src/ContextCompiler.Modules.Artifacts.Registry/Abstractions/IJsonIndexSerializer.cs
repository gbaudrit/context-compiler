using ContextCompiler.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Modules.Artifacts.Registry.Abstractions
{
    internal interface IJsonIndexSerializer
    {
        string Serialize(ArtifactsIndex index);

        ArtifactsIndex Deserialize(string value);
    }
}
