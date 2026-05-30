using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Modules.Abstractions.Skills;

public interface ISkillProvider
{
    string ProviderId { get; }

    Task<IReadOnlyList<SkillDescriptor>> SearchAsync(SkillQuery query, CancellationToken cancellationToken);

    Task<SkillDescriptor?> ResolveAsync(SkillReference reference, CancellationToken cancellationToken);

    Task<SkillPackage> RestoreAsync(SkillDescriptor descriptor, CancellationToken cancellationToken);

    Task<SkillRestoreResult> RestoreWithValidationAsync(SkillDescriptor descriptor, RestoreOptions options, CancellationToken cancellationToken);

    Task<IReadOnlyList<ISkillInfos>> GetSkillInfos(string id, CancellationToken cancellationToken);
}

public sealed record SkillQuery(string? Text = null, IReadOnlyDictionary<string, string>? Filters = null);

public sealed record SkillDescriptor(
    SkillReference Reference,
    string Name,
    string? Description,
    string ResolvedVersion,
    string SourceUri,
    bool Trusted);

public sealed record SkillPackage(
    SkillDescriptor Descriptor,
    IStoreContainer CachePath,
    string Checksum,
    IReadOnlyList<IStoreResource> Files);

public sealed record RestoreOptions(
    bool IncludeValidation = true,
    TrustMode TrustMode = TrustMode.Permissive,
    bool VerifyChecksum = true,
    bool CheckStructure = true
);

public enum TrustMode
{
    Permissive,  // Allow untrusted sources with warnings
    Strict       // Block untrusted sources
}

public sealed record SkillRestoreResult(
    SkillPackage Package,
    IReadOnlyList<RestoreFinding> Findings
);

public sealed record RestoreFinding(
    string Code,
    RestoreSeverity Severity,
    string Message
);

public enum RestoreSeverity
{
    Info,
    Warning,
    Error
}
