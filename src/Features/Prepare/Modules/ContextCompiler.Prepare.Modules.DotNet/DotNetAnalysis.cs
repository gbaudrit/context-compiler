using System.Text.Json.Serialization;

namespace ContextCompiler.Prepare.Modules.DotNet;

public sealed class DotNetAnalysis
{
    [JsonPropertyName("schemaVersion")] public int SchemaVersion { get; init; } = 1;
    [JsonPropertyName("detected")] public bool Detected { get; init; }
    [JsonPropertyName("solutions")] public List<string> Solutions { get; init; } = [];
    [JsonPropertyName("projects")] public List<DotNetProject> Projects { get; init; } = [];
    [JsonPropertyName("centralPackageManagement")] public CentralPackageManagement CentralPackageManagement { get; init; } = new();
    [JsonPropertyName("buildFiles")] public List<string> BuildFiles { get; init; } = [];
    [JsonPropertyName("summary")] public DotNetSummary Summary { get; init; } = new();
    [JsonPropertyName("diagnostics")] public List<string> Diagnostics { get; init; } = [];
}

public sealed class DotNetProject
{
    [JsonPropertyName("path")] public string Path { get; init; } = string.Empty;
    [JsonPropertyName("sdk")] public string? Sdk { get; init; }
    [JsonPropertyName("targetFrameworks")] public List<string> TargetFrameworks { get; init; } = [];
    [JsonPropertyName("outputType")] public string? OutputType { get; init; }
    [JsonPropertyName("packageReferences")] public List<DotNetPackageReference> PackageReferences { get; init; } = [];
    [JsonPropertyName("projectReferences")] public List<string> ProjectReferences { get; init; } = [];
    [JsonPropertyName("isTestProject")] public bool IsTestProject { get; init; }
}

public sealed class DotNetPackageReference
{
    [JsonPropertyName("id")] public string Id { get; init; } = string.Empty;
    [JsonPropertyName("version")] public string? Version { get; init; }
}

public sealed class CentralPackageManagement
{
    [JsonPropertyName("detected")] public bool Detected { get; init; }
    [JsonPropertyName("files")] public List<string> Files { get; init; } = [];
}

public sealed class DotNetSummary
{
    [JsonPropertyName("projectCount")] public int ProjectCount { get; init; }
    [JsonPropertyName("testProjectCount")] public int TestProjectCount { get; init; }
    [JsonPropertyName("targetFrameworks")] public List<string> TargetFrameworks { get; init; } = [];
    [JsonPropertyName("packageCount")] public int PackageCount { get; init; }
}
