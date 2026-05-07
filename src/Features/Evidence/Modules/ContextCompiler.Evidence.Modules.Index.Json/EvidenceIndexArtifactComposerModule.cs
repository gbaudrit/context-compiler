using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Evidence.Modules.Index.Json;

public sealed class EvidenceIndexArtifactComposerModule(ILogger<EvidenceIndexArtifactComposerModule> logger, IReasoningIr ir, IOutput output) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("evidence.index.json", GlobalPipelineModuleKinds.ReportComposition, priority: 10);

    private static readonly JsonSerializerOptions s_jsonIndentedOptions = new() { WriteIndented = true };

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        int distinctEvidenceCount = ir.Fragments.Select(f => f.Evidence.EvidenceKey).Distinct().Count();
        List<ITag> distinctsTags = [.. ir.Fragments.SelectMany(f => f.Tags).Distinct()];
        Dictionary<string, int> evidenceCountByTag = [];
        foreach (ITag? tag in distinctsTags)
        {
            evidenceCountByTag[$"{tag.Name}:{tag.Value}"] = ir.Fragments.Count(f => f.Tags.Contains(tag));
        }

        var evidence = ir.Fragments.Select(f => new
        {
            ek = f.Evidence.EvidenceKey,
            er = f.Evidence.EvidenceRevision,
            source = new { path = f.Source.Path, locator = f.Source.Locator },
            tags = f.Tags
        }).ToList();

        var evidenceStats = new
        {
            totalDistinctEvidence = distinctEvidenceCount,
            totalEvidenceByTag = evidenceCountByTag
        };

        logger.LogInformation("Writing {Count} evidence items to index.", evidence.Count);

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("evidence.index.json")
                          .WithContent(JsonSerializer.Serialize(evidence, s_jsonIndentedOptions))
                          .WithDescription("Evidence index file")
                          .WithGeneratedBy(GetType());
        });

        output.AddArtifact(builder =>
        {
            return builder.WithFileName("evidence.stats.json")
                          .WithContent(JsonSerializer.Serialize(evidenceStats, s_jsonIndentedOptions))
                          .WithDescription("Evidence statistics file")
                          .WithGeneratedBy(GetType());
        });

        return context.Success();
    }
}
