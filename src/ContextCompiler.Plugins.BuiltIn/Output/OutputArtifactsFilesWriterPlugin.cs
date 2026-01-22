using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Ports;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class OutputArtifactsFilesWriterPlugin(IFileSystem fs, ILogger<OutputArtifactsFilesWriterPlugin> logger) : IOutputArtifactsFilesWriterPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.writer", PluginKinds.OutputWriter, priority: 10);

        public ValueTask Run(IOutput output, CancellationToken ct)
        {
            foreach (var artifact in output.Artifacts)
            {
                var p = Path.Combine(output.Path, artifact.FileName);
                fs.WriteAllText(p, artifact.Content);

                logger.LogInformation("Wrote output artifact file: {Path}", p);
            }
            
            return ValueTask.CompletedTask;
        }

    }
}
