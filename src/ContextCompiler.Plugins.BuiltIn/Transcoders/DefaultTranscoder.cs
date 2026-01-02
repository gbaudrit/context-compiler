using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Transcoders;

public sealed class DefaultTranscoder : ITranscoderPlugin
{
    private System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.transcoder.default", PluginKinds.Transcoder, priority: 0);

    public bool CanTranscode(DataEnvelope envelope) => envelope.Shape is DataShape.Linear or DataShape.Tabular;

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(DataEnvelope envelope, SourceRef source, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (envelope.Shape == DataShape.Linear && envelope.Payload is string s)
        {
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("text:full", s, new Dictionary<string,string>{{"shape","linear"}})
            });
        }

        if (envelope.Shape == DataShape.Tabular)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(envelope.Payload, jsonSerializerOptions);
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("table:json", json, new Dictionary<string,string>{{"shape","tabular"}})
            });
        }

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>(Array.Empty<TranscodedFragment>());
    }
}
