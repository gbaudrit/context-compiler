using System.Text.Json.Serialization;

namespace ContextCompiler.Connectors.Modules.Git.Configurations;

public sealed class GitFetcherFileSection
{
    [JsonPropertyName("repositories")]
    public List<GitRepositoryFetchConfig> Repositories { get; set; } = [];
}

public sealed class GitRepositoryFetchConfig
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("repository")]
    public string Repository { get; set; } = string.Empty;

    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("refresh")]
    public bool Refresh { get; set; }

    [JsonPropertyName("depth")]
    public int? Depth { get; set; }

    [JsonPropertyName("includes")]
    public string[] Includes { get; set; } = ["**/*"];

    [JsonPropertyName("excludes")]
    public string[] Excludes { get; set; } = [];

    [JsonPropertyName("tags")]
    public string[] Tags { get; set; } = [];
}
