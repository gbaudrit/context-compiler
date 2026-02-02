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
            int distinctEvidenceCount = ir.Fragments.Select(f => f.Evidence.EvidenceKey).Distinct().Count();
            List<ITag> distinctsTags = [.. ir.Fragments.SelectMany(f => f.Tags).Distinct()];
            Dictionary<string, int> evidencesCountByTag = [];
            foreach (ITag? tag in distinctsTags)
            {
                evidencesCountByTag[$"{tag.Name}:{tag.Value}"] = ir.Fragments.Count(f => f.Tags.Contains(tag));
            }


            var evidences = ir.Fragments.Select(f => new
            {
                ek = f.Evidence.EvidenceKey,
                er = f.Evidence.EvidenceRevision,
                source = new { path = f.Source.Path, locator = f.Source.Locator },
                tags = f.Tags
            }).ToList();

            var evidenceIndex = new
            {
                summary = new
                {
                    totalDistinctEvidences = distinctEvidenceCount,
                    totalEvidencesByTag = evidencesCountByTag
                },
                evidences
            };

            logger.LogInformation("Writing {Count} evidence items to index.", evidences.Count);

            output.AddArtifact(builder =>
            {
                return builder.WithFileName("evidence.index.json")
                              .WithContent(JsonSerializer.Serialize(evidenceIndex, s_jsonIndentedOptions));
            });

            return Task.CompletedTask;
        }
    }
}
