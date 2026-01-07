using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Transcoders;

public sealed class DefaultTranscoder(ILogger<DefaultTranscoder> logger, ITagBuilder tagBuilder) : ITranscoderPlugin
{
    private System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.transcoder.default", PluginKinds.Transcoder, priority: 0);

    public bool CanTranscode(IDataEnvelope envelope) => envelope.Shape is DataShape.Linear or DataShape.Tabular;

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, ISourceRef source, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("DefaultTranscoder processing envelope with shape {Shape} from source {Source}", envelope.Shape, source.Path);

        if (envelope.Shape == DataShape.Linear && envelope.Payload is string s)
        {
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("text:full", s) { Tags = new List<ITag>{ tagBuilder.Build("shape","linear")}}
            });
        }

        if (envelope.Shape == DataShape.Tabular)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(envelope.Payload, jsonSerializerOptions);
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("table:json", json) { Tags = new List<ITag>{ tagBuilder.Build("shape", "tabular") }}
            });
        }

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>(Array.Empty<TranscodedFragment>());
    }
}
