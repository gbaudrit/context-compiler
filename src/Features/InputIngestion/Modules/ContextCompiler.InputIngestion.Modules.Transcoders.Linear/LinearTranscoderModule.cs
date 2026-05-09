using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.InputIngestion.Modules.Transcoders.Linear;

public sealed class LinearTranscoderModule(ILogger<LinearTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder, IFragmentBuilder fragmentBuilder) : IDataPartPipelineModule
{

    public DataPartModuleMetadata Metadata => IDataPartPipelineModule.Meta("input-ingestion.transcoder.linear", DataPartPipelineModuleKinds.Transcoders, priority: 10);

    public bool CanProcess(IInputItemContext inputItemContext, IDataPart part)
    {
        return inputItemContext.Data.DataEnvelope.Shape is DataShape.Linear;
    }

    public Task<IInputItemContextPatch> Run(IInputItemContext inputItemContext, IInputItemContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
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

        return patcher.WithFragments(
            [
                fragmentBuilder.InitNew()
                               .ForDataPart(part)
                               .WithContent(content)
                               .WithLocator(locator)
                               .WithFilePath(part.Source.Path)
                               .WithTags(tagsBuilder.InitNewFrom([tagBuilder.Build("shape", "linear")]).Build())
                               .Build(),
            ]).BuildAsTask();
    }
}
