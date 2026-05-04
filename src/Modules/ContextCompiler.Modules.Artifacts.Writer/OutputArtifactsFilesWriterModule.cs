using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Artifacts.Writer;

public sealed class OutputArtifactsFilesWriterModule(IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterModule> logger) : IOutputArtifactsFilesWriterModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("artifacts.writer", GlobalPipelineModuleKinds.ArtifactPersistence, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        foreach (IOutputArtifact artifact in output.Artifacts)
        {
            string p = Path.Combine(output.Path, artifact.FileName);
            fs.WriteAllText(p, artifact.Content);

            logger.LogInformation("Wrote output artifact file: {Path}", p);
        }

        return context.Success();
    }

}
