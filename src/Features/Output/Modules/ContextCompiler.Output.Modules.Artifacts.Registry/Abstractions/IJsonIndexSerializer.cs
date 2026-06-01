using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions
{
    internal interface IJsonIndexSerializer
    {
        string Serialize(ArtifactsIndex index);

        ArtifactsIndex Deserialize(string value);
    }
}
