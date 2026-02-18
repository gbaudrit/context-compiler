using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Transcoders;

public sealed class DefaultTranscoder(ILogger<DefaultTranscoder> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : ITranscoderPlugin
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.transcoder.default", GlobalPipelinePluginKinds.Transcoder, priority: 0);

    public bool CanTranscode(IDataEnvelope envelope)
    {
        return envelope.Shape is DataShape.Linear or DataShape.Tabular;
    }

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, IDataPart dataPart, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("DefaultTranscoder processing envelope with shape {Shape} from source {Source}", envelope.Shape, dataPart.Source.Path);

        if (envelope.Shape == DataShape.Linear)
        {
            string locator = "unknown";
            string content = "";
            if (dataPart.Payload is IFileInfos)
            {
                locator = "file:full";
                content = (dataPart.Payload as IFileInfos)!.Path;
            }
            else if (dataPart.Payload is string s)
            {
                locator = "text:full";
                content = s;
            }

            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(
            [
                new TranscodedFragment(locator, content) { Tags =  tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "linear")]).AddRange(dataPart.Tags).Build()}
            ]);
        }

        if (envelope.Shape == DataShape.Tabular)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(dataPart.Payload, jsonSerializerOptions);
            return Task.FromResult<IReadOnlyList<TranscodedFragment>>(
            [
                new TranscodedFragment("table:json", json) { Tags = tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "tabular")]).AddRange(dataPart.Tags).Build() }
            ]);
        }

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>([]);
    }
}
