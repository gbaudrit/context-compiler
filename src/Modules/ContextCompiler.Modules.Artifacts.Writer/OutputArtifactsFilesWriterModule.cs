using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Artifacts.Writer;

public sealed class OutputArtifactsFilesWriterModule(IPrompt prompt, IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterModule> logger) : IOutputArtifactsFilesWriterModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("artifacts.writer", GlobalPipelineModuleKinds.OutputWriter, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        foreach (IOutputArtifact artifact in prompt.Artifacts)
        {
            string p = Path.Combine(output.Path, artifact.FileName);
            fs.WriteAllText(p, artifact.Content);

            logger.LogInformation("Wrote output artifact file: {Path}", p);
        }

        return Task.CompletedTask;
    }

}
