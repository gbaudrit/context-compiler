using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Datas.Transcoders.Linear;

public sealed class LinearTranscoderModule(ILogger<LinearTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : IDocumentPartPipelineModule
{

    public DocumentPartModuleMetadata Metadata => IDocumentPartPipelineModule.Meta("datas.transcoder.linear", DocumentPartPipelineModuleKinds.Transcoders, priority: 10);

    public bool CanProcess(IDocumentContext documentContext, IDataPart part)
    {
        return documentContext.Data.DataEnvelope.Shape is DataShape.Linear;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("LinearTranscoder processing envelope from source {Source}", part.Source.Path);

        string locator = "unknown";
        string content = "";

        if (part.Payload is IFileInfos fileInfos)
        {
            locator = "file:full";
            content = fileInfos.Path;
        }
        else if (part.Payload is string s)
        {
            locator = part.Source.Locator ?? "text:full";
            content = s;
        }

        return patcher.WithTranscodedFragments(
        [
            new TranscodedFragment(locator, content)
            {
                Tags = tagsBuilder
                    .InitNewFrom([tagBuilder.Build("shape", "linear")])
                    .AddRange(part.Tags)
                    .Build()
            }
        ]).BuildAsTask();
    }
}
