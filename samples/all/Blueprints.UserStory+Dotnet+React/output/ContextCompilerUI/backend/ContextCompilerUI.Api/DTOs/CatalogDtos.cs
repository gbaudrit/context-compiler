namespace ContextCompilerUI.Api.DTOs;

// --- Modules ---
public record ModuleDto(
    string Id,
    string Name,
    string Description,
    string Category,
    string NuGetPackage,
    string PipelinePhase
);

// --- Packs ---
public record PackDto(
    string Id,
    string Name,
    string Description,
    IReadOnlyList<string> ModuleIds
);

// --- Blueprints ---
public record BlueprintDto(
    string Id,
    string Name,
    string Description,
    IReadOnlyList<BlueprintStepDto> Steps,
    IReadOnlyList<BlueprintCommandDto> Commands,
    IReadOnlyList<string> PackIds
);

public record BlueprintStepDto(string Title, string Description);

public record BlueprintCommandDto(string Name, string Description, string Example);

// --- Artifacts ---
public record ArtifactDto(
    string Filename,
    string Description,
    string MimeType,
    long Size,
    string GeneratedBy
);

public record ArtifactsIndexDto(IReadOnlyList<ArtifactDto> Artifacts);

// --- Compile ---
public record CompileRequestDto(
    IReadOnlyList<string> ModuleIds,
    IReadOnlyList<string> PackIds,
    IReadOnlyList<string> BlueprintIds,
    Dictionary<string, string>? Options
);

public record CompileResultDto(
    string PromptContext,
    ArtifactsIndexDto ArtifactsIndex,
    bool Success,
    string? ErrorMessage
);
