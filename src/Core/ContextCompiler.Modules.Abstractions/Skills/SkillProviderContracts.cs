namespace ContextCompiler.Modules.Abstractions.Skills;

public interface ISkillProvider
{
    string ProviderId { get; }

    Task<IReadOnlyList<SkillDescriptor>> SearchAsync(SkillQuery query, CancellationToken cancellationToken);

    Task<SkillDescriptor?> ResolveAsync(SkillReference reference, CancellationToken cancellationToken);

    Task<SkillPackage> FetchAsync(SkillDescriptor descriptor, CancellationToken cancellationToken);
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
    string CachePath,
    string CompiledPath,
    string Checksum,
    IReadOnlyList<string> Files);
