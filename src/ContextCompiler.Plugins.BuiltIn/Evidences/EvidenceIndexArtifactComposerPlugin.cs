using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Evidences
{
    internal sealed class EvidenceIndexArtifactComposerPlugin(ILogger<EvidenceIndexArtifactComposerPlugin> logger, IReasoningIr ir, IOutput output) : IOutputArtifactComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.evidence.index.json", GlobalPipelinePluginKinds.OutputArtifactComposer, priority: 10);

        private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

        public Task Run(CancellationToken cancellationToken)
        {
            var evidenceIndex = ir.Fragments.Select(f => new
            {
                ek = f.Evidence.EvidenceKey,
                er = f.Evidence.EvidenceRevision,
                source = new { path = f.Source.Path, locator = f.Source.Locator },
                tags = f.Tags
            }).ToList();

            logger.LogInformation("Writing {Count} evidence items to index.", evidenceIndex.Count);

            output.AddArtifact(builder =>
            {
                return builder.WithFileName("evidence.index.json")
                              .WithContent(JsonSerializer.Serialize(evidenceIndex, s_jsonIndentedOptions));
            });

            return Task.CompletedTask;
        }
    }
}
