using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Evidences.Index.Json;

public sealed class EvidenceIndexArtifactComposerModule(ILogger<EvidenceIndexArtifactComposerModule> logger, IReasoningIr ir, IPrompt prompt) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("evidences.index.json", GlobalPipelineModuleKinds.OutputArtifactComposer, priority: 10);

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

        var evidencesStats = new
        {
            totalDistinctEvidences = distinctEvidenceCount,
            totalEvidencesByTag = evidencesCountByTag
        };

        logger.LogInformation("Writing {Count} evidence items to index.", evidences.Count);

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("evidences.index.json")
                          .WithContent(JsonSerializer.Serialize(evidences, s_jsonIndentedOptions))
                          .WithDescription("Evidences index file")
                          .WithGeneratedBy(GetType());
        });

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("evidences.stats.json")
                          .WithContent(JsonSerializer.Serialize(evidencesStats, s_jsonIndentedOptions))
                          .WithDescription("Evidences statistics file")
                          .WithGeneratedBy(GetType());
        });

        return Task.CompletedTask;
    }
}
