using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Datas.Transcoders.Linear;

public sealed class LinearTranscoderModule(ILogger<LinearTranscoderModule> logger, ITagBuilder tagBuilder, ITagsBuilder tagsBuilder) : ITranscoderModule
{

    public ModuleMetadata Metadata => IModule.Meta("datas.transcoder.linear", GlobalPipelineModuleKinds.Transcoder, priority: 10);

    public bool CanTranscode(IDataEnvelope envelope)
    {
        return envelope.Shape is DataShape.Linear;
    }

    public Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, IDataPart dataPart, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogTrace("LinearTranscoder processing envelope from source {Source}", dataPart.Source.Path);

        string locator = "unknown";
        string content = "";

        if (dataPart.Payload is IFileInfos fileInfos)
        {
            locator = "file:full";
            content = fileInfos.Path;
        }
        else if (dataPart.Payload is string s)
        {
            locator = dataPart.Source.Locator ?? "text:full";
            content = s;
        }

        return Task.FromResult<IReadOnlyList<TranscodedFragment>>(
        [
            new TranscodedFragment(locator, content)
            {
                Tags = tagsBuilder
                    .InitNewFrom([tagBuilder.Build("shape", "linear")])
                    .AddRange(dataPart.Tags)
                    .Build()
            }
        ]);
    }
}
