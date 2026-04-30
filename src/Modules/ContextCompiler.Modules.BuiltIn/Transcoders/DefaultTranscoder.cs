using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.BuiltIn.Transcoders;

public sealed class DefaultTranscoder(ILogger<DefaultTranscoder> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : IDocumentPartPipelineModule
{
    private readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public DocumentPartModuleMetadata Metadata => IDocumentPartPipelineModule.Meta("builtin.transcoder.default", DocumentPartPipelineModuleKinds.Guards, priority: 0);

    public bool CanProcess(IDocumentContext documentContext, IDataPart part)
    {
        return documentContext.Data.DataEnvelope.Shape is DataShape.Linear or DataShape.Tabular;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("DefaultTranscoder processing envelope with shape {Shape} from source {Source}", documentContext.Data.DataEnvelope.Shape, part.Source.Path);

        if (documentContext.Data.DataEnvelope.Shape == DataShape.Linear)
        {
            string locator = "unknown";
            string content = "";
            if (part.Payload is IFileInfos)
            {
                locator = "file:full";
                content = (part.Payload as IFileInfos)!.Path;
            }
            else if (part.Payload is string s)
            {
                locator = part.Source.Locator ?? "text:full";
                content = s;
            }

            return patcher.WithTranscodedFragments(
            [
                new TranscodedFragment(locator, content) { Tags =  tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "linear")]).AddRange(part.Tags).Build()}
            ]).BuildAsTask();
        }

        if (documentContext.Data.DataEnvelope.Shape == DataShape.Tabular)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(part.Payload, jsonSerializerOptions);
            return patcher.WithTranscodedFragments(
            [
                new TranscodedFragment("table:json", json) { Tags = tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "tabular")]).AddRange(part.Tags).Build() }
            ]).BuildAsTask();
        }

        return patcher.NoChangesAsTask();
    }
}
