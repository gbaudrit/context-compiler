using System.Text.Json;

using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputJsonArtifactWriter(IOutputArtifactWriter outputArtifactWriter) : IOutputJsonArtifactWriter
    {
        private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

        public Task Write<T>(string name,T content)
        {
            return outputArtifactWriter.Write(name, JsonSerializer.Serialize(content, s_jsonIndentedOptions));
        }

    }
}
