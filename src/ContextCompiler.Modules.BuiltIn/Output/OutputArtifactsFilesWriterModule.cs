using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.BuiltIn.Output
{
    internal sealed class OutputArtifactsFilesWriterModule(IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterModule> logger) : IOutputArtifactsFilesWriterModule
    {
        public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.output.writer", GlobalPipelineModuleKinds.OutputWriter, priority: 10);

        public Task Run(CancellationToken ct)
        {
            foreach (IOutputArtifact artifact in output.Artifacts)
            {
                string p = Path.Combine(output.Path, artifact.FileName);
                fs.WriteAllText(p, artifact.Content);

                logger.LogInformation("Wrote output artifact file: {Path}", p);
            }

            return Task.CompletedTask;
        }

    }
}
