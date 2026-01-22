using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Transcoders;

public sealed class DefaultTranscoder(ILogger<DefaultTranscoder> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : ITranscoderPlugin
{
    private System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.transcoder.default", GlobalPipelinePluginKinds.Transcoder, priority: 0);

    public bool CanTranscode(IDataEnvelope envelope) => envelope.Shape is DataShape.Linear or DataShape.Tabular;

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, IDataPart dataPart, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("DefaultTranscoder processing envelope with shape {Shape} from source {Source}", envelope.Shape, dataPart.Source.Path);

        if (envelope.Shape == DataShape.Linear && dataPart.Payload is string s)
        {
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("text:full", s) { Tags =  tagsBuilder.InitNewFrom(new List<ITag>{ tagBuilder.Build("shape", "linear")}).AddRange(dataPart.Tags).Build()}
            });
        }

        if (envelope.Shape == DataShape.Tabular)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(dataPart.Payload, jsonSerializerOptions);
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(new[]
            {
                new TranscodedFragment("table:json", json) { Tags = tagsBuilder.InitNewFrom(new List<ITag>{ tagBuilder.Build("shape", "tabular")}).AddRange(dataPart.Tags).Build() }
            });
        }

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>(Array.Empty<TranscodedFragment>());
    }
}
