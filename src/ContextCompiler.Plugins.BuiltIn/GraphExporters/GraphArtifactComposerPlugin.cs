using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Evidences
{
    internal sealed class GraphArtifactComposerPlugin(ILogger<EvidenceIndexArtifactComposerPlugin> logger, IReasoningIr ir, IOutput output) : IOutputArtifactComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.artifact.evidence.index.json", PluginKinds.OutputArtifactComposer, priority: 10);

        private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

        public async ValueTask Compose(CancellationToken cancellationToken)
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
