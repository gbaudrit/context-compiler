using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Output.Modules.Artifacts.Registry.Abstractions;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry
{
    internal sealed class JsonIndexSerializer : IJsonIndexSerializer, IOutputArtifactSerializer
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };


        public bool CanProcess(string name)
        {
            return name.EndsWith("artifacts.index.json", StringComparison.InvariantCultureIgnoreCase);
        }

        public string Serialize(ArtifactsIndex index)
        {
            return JsonSerializer.Serialize(index, JsonOpts);
        }

        public ArtifactsIndex Deserialize(string value)
        {
            return JsonSerializer.Deserialize<ArtifactsIndex>(value, JsonOpts) ?? throw new InvalidOperationException("Failed to deserialize JSON index");
        }
    }
}
