namespace ContextCompilerUI.Api.Models;

public record ModuleItem(
    string Id,
    string Name,
    string Description,
    string Category,
    string NuGetPackage,
    string PipelinePhase
);

public record PackItem(
    string Id,
    string Name,
    string Description,
    IReadOnlyList<string> ModuleIds
);

public record BlueprintItem(
    string Id,
    string Name,
    string Description,
    IReadOnlyList<BlueprintStep> Steps,
    IReadOnlyList<BlueprintCommand> Commands,
    IReadOnlyList<string> PackIds
);

public record BlueprintStep(string Title, string Description);

public record BlueprintCommand(string Name, string Description, string Example);

public record ArtifactItem(
    string Filename,
    string Description,
    string MimeType,
    long Size,
    string GeneratedBy
);

public record ArtifactsIndex(IReadOnlyList<ArtifactItem> Artifacts);
