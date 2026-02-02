using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Ports;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class OutputArtifactsFilesWriterPlugin(IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterPlugin> logger) : IOutputArtifactsFilesWriterPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.writer", GlobalPipelinePluginKinds.OutputWriter, priority: 10);

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
