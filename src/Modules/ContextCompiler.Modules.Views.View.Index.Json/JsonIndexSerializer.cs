using System.Text.Json;

using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Modules.Views.View.Index.Json
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
            return name.EndsWith(".index.json", StringComparison.InvariantCultureIgnoreCase);
        }

        public string Serialize(JsonIndex index)
        {
            return JsonSerializer.Serialize(index, JsonOpts);
        }

        public JsonIndex Deserialize(string value)
        {
            return JsonSerializer.Deserialize<JsonIndex>(value, JsonOpts) ?? throw new InvalidOperationException("Failed to deserialize JSON index");
        }
    }
}
