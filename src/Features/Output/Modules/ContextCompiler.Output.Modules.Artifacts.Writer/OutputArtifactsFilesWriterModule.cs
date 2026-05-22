using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Output.Modules.Artifacts.Writer;

public sealed class OutputArtifactsFilesWriterModule(IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterModule> logger) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("artifacts.writer", GlobalPipelineModuleKinds.ArtifactPersistence, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        if (!output.Artifacts.Any())
        {
            logger.LogInformation("No output artifacts to write for output");
            return await context.Success();
        }

        foreach (IOutputArtifact artifact in output.Artifacts)
        {
            await artifact.StoreResource.WriteAllText(artifact.Content, cancellationToken);

            logger.LogInformation("Wrote output artifact : {Uri}", artifact.StoreResource.Uri);
        }

        return await context.Success();
    }

}
