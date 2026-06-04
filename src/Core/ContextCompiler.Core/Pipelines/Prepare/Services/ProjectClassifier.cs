using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class ProjectClassifier(ILogger<ProjectClassifier> logger) : IProjectClassifier
{
    private static readonly Dictionary<string, (string Technology, string Language, string Framework)> ExtensionMap =
        new(StringComparer.OrdinalIgnoreCase)
        {
            [".cs"] = ("dotnet", "csharp", ".NET"),
            [".csproj"] = ("dotnet", "csharp", ".NET"),
            [".sln"] = ("dotnet", "csharp", ".NET"),
            [".vb"] = ("dotnet", "vbnet", ".NET"),
            [".fs"] = ("dotnet", "fsharp", ".NET"),
            [".fsproj"] = ("dotnet", "fsharp", ".NET"),
            [".ts"] = ("nodejs", "typescript", "TypeScript"),
            [".tsx"] = ("nodejs", "typescript", "React"),
            [".js"] = ("nodejs", "javascript", "JavaScript"),
            [".jsx"] = ("nodejs", "javascript", "React"),
            [".mjs"] = ("nodejs", "javascript", "JavaScript"),
            [".cjs"] = ("nodejs", "javascript", "JavaScript"),
            [".py"] = ("python", "python", "Python"),
            [".java"] = ("java", "java", "Java"),
            [".kt"] = ("java", "kotlin", "Kotlin"),
            [".go"] = ("go", "go", "Go"),
            [".rs"] = ("rust", "rust", "Rust"),
            [".rb"] = ("ruby", "ruby", "Ruby"),
            [".php"] = ("php", "php", "PHP"),
            [".cpp"] = ("cpp", "cpp", "C++"),
            [".hpp"] = ("cpp", "cpp", "C++"),
            [".c"] = ("c", "c", "C"),
            [".h"] = ("c", "c", "C"),
            [".swift"] = ("swift", "swift", "Swift"),
            [".md"] = ("docs", "markdown", "Markdown"),
            [".sql"] = ("database", "sql", "SQL"),
            [".yml"] = ("config", "yaml", "YAML"),
            [".yaml"] = ("config", "yaml", "YAML"),
        };

    private static readonly Dictionary<string, (string Technology, string Framework)> KnownFileMap =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["package.json"] = ("nodejs", "Node.js"),
            ["tsconfig.json"] = ("nodejs", "TypeScript"),
            ["pom.xml"] = ("java", "Maven"),
            ["build.gradle"] = ("java", "Gradle"),
            ["build.gradle.kts"] = ("java", "Gradle"),
            ["requirements.txt"] = ("python", "Python"),
            ["pyproject.toml"] = ("python", "Python"),
            ["Pipfile"] = ("python", "Python"),
            ["Gemfile"] = ("ruby", "Ruby"),
            ["Cargo.toml"] = ("rust", "Cargo"),
            ["go.mod"] = ("go", "Go modules"),
            ["composer.json"] = ("php", "Composer"),
            ["Dockerfile"] = ("docker", "Docker"),
            ["docker-compose.yml"] = ("docker", "Docker Compose"),
            ["docker-compose.yaml"] = ("docker", "Docker Compose"),
            ["Directory.Build.props"] = ("dotnet", ".NET"),
            ["global.json"] = ("dotnet", ".NET SDK"),
        };

    public Task<ProjectClassification> ClassifyAsync(ProjectInventory inventory, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(inventory);
        cancellationToken.ThrowIfCancellationRequested();

        HashSet<string> technologies = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> frameworks = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> languages = new([], StringComparer.OrdinalIgnoreCase);

        foreach (string extension in inventory.Extensions)
        {
            if (ExtensionMap.TryGetValue(extension, out (string Technology, string Language, string Framework) m))
            {
                _ = technologies.Add(m.Technology);
                _ = languages.Add(m.Language);
                _ = frameworks.Add(m.Framework);
            }
        }

        foreach (string fileName in inventory.Technologies)
        {
            if (KnownFileMap.TryGetValue(fileName, out (string Technology, string Framework) m))
            {
                _ = technologies.Add(m.Technology);
                _ = frameworks.Add(m.Framework);
            }
        }

        ProjectClassification classification = new()
        {
            Technologies = [.. technologies.OrderBy(t => t, StringComparer.OrdinalIgnoreCase)],
            Frameworks = [.. frameworks.OrderBy(f => f, StringComparer.OrdinalIgnoreCase)],
            Languages = [.. languages.OrderBy(l => l, StringComparer.OrdinalIgnoreCase)],
        };

        logger.LogInformation(
            "Classified project: {TechnologyCount} technologies, {FrameworkCount} frameworks, {LanguageCount} languages",
            classification.Technologies.Count,
            classification.Frameworks.Count,
            classification.Languages.Count);

        return Task.FromResult(classification);
    }
}
