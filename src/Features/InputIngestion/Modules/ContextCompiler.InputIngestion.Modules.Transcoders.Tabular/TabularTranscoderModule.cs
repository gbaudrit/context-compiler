using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.InputIngestion.Modules.Transcoders.Tabular;

public sealed class TabularTranscoderModule(ILogger<TabularTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder, IFragmentBuilder fragmentBuilder) : IDataPartPipelineModule
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public DataPartModuleMetadata Metadata => IDataPartPipelineModule.Meta("input-ingestion.transcoder.tabular", DataPartPipelineModuleKinds.Transcoders, priority: 10);

    public bool CanProcess(IInputItemContext inputItemContext, IDataPart part)
    {
        return inputItemContext.Data.DataEnvelope.Shape is DataShape.Tabular;
    }

    public Task<IInputItemContextPatch> Run(IInputItemContext inputItemContext, IInputItemContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("TabularTranscoder processing envelope from source {Source}", part.Source.Path);
        string json = System.Text.Json.JsonSerializer.Serialize(part.Payload, jsonSerializerOptions);

        return patcher.WithFragments(
            [
                fragmentBuilder.InitNew()
                               .ForDataPart(part)
                               .WithContent(json)
                               .WithLocator("table:json")
                               .WithFilePath(part.Source.Path)
                               .WithTags(tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "tabular")]).Build())
                               .Build()
            ]).BuildAsTask();
    }
}
