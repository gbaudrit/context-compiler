using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Datas.Transcoders.Tabular;

public sealed class TabularTranscoderModule(ILogger<TabularTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder, IFragmentBuilder fragmentBuilder) : IDocumentPartPipelineModule
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public DocumentPartModuleMetadata Metadata => IDocumentPartPipelineModule.Meta("datas.transcoder.tabular", DocumentPartPipelineModuleKinds.Transcoders, priority: 10);

    public bool CanProcess(IDocumentContext documentContext, IDataPart part)
    {
        return documentContext.Data.DataEnvelope.Shape is DataShape.Tabular;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
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
