using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class PreparePlanner(ILogger<PreparePlanner> logger) : IPreparePlanner
{
    private static readonly Dictionary<string, IReadOnlyCollection<string>> TechnologyToPipelines =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["dotnet"] =
            [
                "ContextCompiler.Packs.Starter.Standard",
                "ContextCompiler.Prompting",
                "ContextCompiler.Prompting.Modules.Templates.Scriban",
                "ContextCompiler.Prompting.Modules.Engineering.DotNet",
            ],
            ["nodejs"] =
            [
                "ContextCompiler.Packs.Starter.Standard",
                "ContextCompiler.Prompting",
                "ContextCompiler.Prompting.Modules.Templates.Scriban",
            ],
            ["python"] =
            [
                "ContextCompiler.Packs.Starter.Standard",
                "ContextCompiler.Prompting",
                "ContextCompiler.Prompting.Modules.Templates.Scriban",
                "ContextCompiler.Prompting.Modules.Personas.Developers.Python",
            ],
            ["docs"] =
            [
                "ContextCompiler.Packs.Starter.Standard",
                "ContextCompiler.Readers.Packs.Standard",
            ],
        };

    private static readonly Dictionary<string, IReadOnlyCollection<string>> TechnologyToSkills =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["docs"] = ["document-skills@anthropic-agent-skills"],
        };

    private static readonly Dictionary<string, string[]> ExtensionToIncludePatterns =
        new(StringComparer.OrdinalIgnoreCase)
        {
            [".cs"] = ["**/*.cs"],
            [".csproj"] = ["**/*.csproj"],
            [".ts"] = ["**/*.ts"],
            [".tsx"] = ["**/*.tsx"],
            [".js"] = ["**/*.js"],
            [".jsx"] = ["**/*.jsx"],
            [".py"] = ["**/*.py"],
            [".java"] = ["**/*.java"],
            [".kt"] = ["**/*.kt"],
            [".go"] = ["**/*.go"],
            [".rs"] = ["**/*.rs"],
            [".md"] = ["**/*.md"],
        };

    private static readonly string[] DefaultExcludePatterns =
    [
        "**/.git/**",
        "**/.svn/**",
        "**/.hg/**",
        "**/.vs/**",
        "**/.vscode/**",
        "**/.idea/**",
        "**/.ctxc/**",
        "**/bin/**",
        "**/obj/**",
        "**/node_modules/**",
        "**/dist/**",
        "**/build/**",
        "**/out/**",
        "**/target/**",
        "**/packages/**",
        "**/__pycache__/**",
        "**/.venv/**",
        "**/venv/**",
    ];

    public Task<PreparePlan> CreatePlanAsync(
        ProjectInventory inventory,
        string? goal,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(inventory);
        cancellationToken.ThrowIfCancellationRequested();

        logger.LogInformation("Creating prepare plan (goal: {Goal})", goal ?? "<none>");

        HashSet<string> pipelines = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> skills = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> includes = new([], StringComparer.OrdinalIgnoreCase);

        foreach (string technology in inventory.Technologies)
        {
            CollectFromTechnology(technology, pipelines, skills);
        }

        // Inventory.Technologies contains known config file names; map shorthand keys also using extensions.
        HashSet<string> derivedTechnologies = DeriveTechnologyKeys(inventory);
        foreach (string technology in derivedTechnologies)
        {
            CollectFromTechnology(technology, pipelines, skills);
        }

        foreach (string extension in inventory.Extensions)
        {
            if (ExtensionToIncludePatterns.TryGetValue(extension, out string[]? patterns))
            {
                foreach (string pattern in patterns)
                {
                    _ = includes.Add(pattern);
                }
            }
        }

        if (includes.Count == 0)
        {
            _ = includes.Add("**/*");
        }

        if (pipelines.Count == 0)
        {
            _ = pipelines.Add("ContextCompiler.Packs.Starter.Standard");
        }

        PreparePlan plan = new()
        {
            RecommendedSkills = [.. skills.OrderBy(s => s, StringComparer.OrdinalIgnoreCase)],
            RecommendedPipelines = [.. pipelines.OrderBy(p => p, StringComparer.OrdinalIgnoreCase)],
            IncludePatterns = [.. includes.OrderBy(i => i, StringComparer.OrdinalIgnoreCase)],
            ExcludePatterns = DefaultExcludePatterns,
        };

        logger.LogInformation(
            "Plan created: {PipelineCount} pipelines, {SkillCount} skills, {IncludeCount} includes, {ExcludeCount} excludes",
            plan.RecommendedPipelines.Count,
            plan.RecommendedSkills.Count,
            plan.IncludePatterns.Count,
            plan.ExcludePatterns.Count);

        return Task.FromResult(plan);
    }

    private static void CollectFromTechnology(string technology, HashSet<string> pipelines, HashSet<string> skills)
    {
        if (TechnologyToPipelines.TryGetValue(technology, out IReadOnlyCollection<string>? pipelinesForTech))
        {
            foreach (string pipeline in pipelinesForTech)
            {
                _ = pipelines.Add(pipeline);
            }
        }

        if (TechnologyToSkills.TryGetValue(technology, out IReadOnlyCollection<string>? skillsForTech))
        {
            foreach (string skill in skillsForTech)
            {
                _ = skills.Add(skill);
            }
        }
    }

    private static HashSet<string> DeriveTechnologyKeys(ProjectInventory inventory)
    {
        HashSet<string> keys = new([], StringComparer.OrdinalIgnoreCase);

        foreach (string extension in inventory.Extensions)
        {
            switch (extension.ToLowerInvariant())
            {
                case ".cs":
                case ".csproj":
                case ".sln":
                case ".vb":
                case ".fs":
                case ".fsproj":
                    _ = keys.Add("dotnet");
                    break;
                case ".ts":
                case ".tsx":
                case ".js":
                case ".jsx":
                case ".mjs":
                case ".cjs":
                    _ = keys.Add("nodejs");
                    break;
                case ".py":
                    _ = keys.Add("python");
                    break;
                case ".md":
                    _ = keys.Add("docs");
                    break;
                default:
                    break;
            }
        }

        return keys;
    }
}
