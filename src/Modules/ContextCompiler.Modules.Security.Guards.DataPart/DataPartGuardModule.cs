using ContextCompiler.Abstractions.Pipelines.DataPart;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContextCompiler.Modules.Security.Guards.DataPart;

/// <summary>
/// Security guard that filters data parts based on their descriptor properties.
/// </summary>
public sealed class DataPartGuardModule(
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartCatalog dataPartCatalog,
    IOptions<DataPartGuardConfig> configOptions,
    ILogger<DataPartGuardModule> logger) : IDocumentPartPipelineModule
{
    private readonly DataPartGuardConfig _config = configOptions.Value;

    public DocumentPartModuleMetadata Metadata => IDocumentPartPipelineModule.Meta(
        "security.guard.datapart",
        DocumentPartPipelineModuleKinds.Guards,
        priority: 10);

    public bool CanProcess(IDocumentContext documentContext, IDataPart part)
    {
        return true;
    }

    public Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, IDataPart part, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (part is null)
        {
            return patcher.NoChangesAsTask();
        }

        // Evaluate the current part
        if (ShouldExcludePart(part, out string? exclusionReason))
        {
            logger.LogDebug(
                "Part '{PartId}' of type {DataPartType} should be excluded: {Reason}",
                part.PartId,
                part.Type,
                exclusionReason);

            // Add a finding indicating this part should be skipped
            // BuildCompositePartsPass will handle the actual exclusion
            _ = patcher.AddFinding(
                    FindingSeverity.Info,
                    FindingAction.Skip,
                    "CtxGuard.DataPart",
                    $"Part '{part.PartId}' (type: {part.Type}) should be excluded: {exclusionReason}",
                    part.Source);
        }

        return patcher.BuildAsTask();
    }

    private bool ShouldExcludePart(IDataPart part, out string? exclusionReason)
    {
        exclusionReason = null;

        // Get descriptor for this data part type
        IDataPartDescriptor? descriptor = dataPartCatalog.GetDescriptor(part.Type);
        if (descriptor is null)
        {
            // Unknown type - log warning but include by default
            logger.LogWarning("No descriptor found for DataPartType {Type}", part.Type);
            return false;
        }

        // Check if type is explicitly excluded
        if (_config.ExcludedTypes.Contains(part.Type))
        {
            exclusionReason = $"Type {part.Type} is in excluded types list";
            return true;
        }

        // Check if category is excluded
        if (_config.ExcludedCategories.Contains(descriptor.Category))
        {
            exclusionReason = $"Category '{descriptor.Category}' is excluded";
            return true;
        }

        // Check minimum agent context action
        if (_config.MinimumAgentContextAction.HasValue &&
            descriptor.DefaultAgentContextAction < _config.MinimumAgentContextAction.Value)
        {
            exclusionReason = $"Agent context action {descriptor.DefaultAgentContextAction} is below minimum {_config.MinimumAgentContextAction.Value}";
            return true;
        }

        // Check for excluded traits
        if (_config.ExcludedTraits != DataPartTraits.None)
        {
            // Check if any of the excluded traits are present
            foreach (DataPartTraits excludedTrait in Enum.GetValues<DataPartTraits>())
            {
                if (excludedTrait != DataPartTraits.None &&
                    (_config.ExcludedTraits & excludedTrait) == excludedTrait &&
                    descriptor.HasTrait(excludedTrait))
                {
                    exclusionReason = $"Part has excluded trait: {excludedTrait}";
                    return true;
                }
            }
        }

        // Check personal data exclusion
        if (_config.ExcludePersonalData && descriptor.IsPersonalData)
        {
            exclusionReason = "Personal data exclusion is enabled";
            return true;
        }

        // Check sensitive data exclusion
        if (_config.ExcludeSensitiveData && descriptor.HasTrait(DataPartTraits.Sensitive))
        {
            exclusionReason = "Sensitive data exclusion is enabled";
            return true;
        }

        return false;
    }
}
