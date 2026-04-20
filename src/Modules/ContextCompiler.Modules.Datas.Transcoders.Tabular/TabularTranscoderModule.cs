using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Datas.Transcoders.Tabular;

public sealed class TabularTranscoderModule(ILogger<TabularTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : ITranscoderModule
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public ModuleMetadata Metadata => IModule.Meta("datas.transcoder.tabular", GlobalPipelineModuleKinds.Transcoder, priority: 10);

    public bool CanTranscode(IDataEnvelope envelope)
    {
        return envelope.Shape is DataShape.Tabular;
    }

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, IDataPart dataPart, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("TabularTranscoder processing envelope from source {Source}", dataPart.Source.Path);

        string json = System.Text.Json.JsonSerializer.Serialize(dataPart.Payload, jsonSerializerOptions);

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>(
        [
            new TranscodedFragment("table:json", json)
            {
                Tags = tagsBuilder
                    .InitNewFrom([tagBuilder.Build("shape", "tabular")])
                    .AddRange(dataPart.Tags)
                    .Build()
            }
        ]);
    }
}
