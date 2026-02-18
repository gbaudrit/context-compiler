using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;
using ContextCompiler.Plugins.BuiltIn.Evidences;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.GraphExporters
{
    internal sealed class EvidencesIndexExporter(ILogger<EvidenceIndexArtifactComposerPlugin> logger, IReasoningIr ir, IOutput output) : IOutputArtifactComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.artifact.evidence.index.json", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 10);

        private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

        public async Task Run(CancellationToken cancellationToken)
        {
            IGraph graph = await ir.Graph(cancellationToken);
            output.AddArtifact(builder =>
            {
                return builder.WithFileName("reasoning.graph.json")
                              .WithContent(JsonSerializer.Serialize(graph, s_jsonIndentedOptions));
            });

        }
    }
}
