using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Compilation;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Connectors.Git.Configurations;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Connectors.Git;

public sealed class GitRepositoryConnectorModule(
    ICompilationContext compilationContext,
    IConfigProvider configProvider,
    ICompiledWorkingFolder compiledWorkingFolder,
    IGitProcessClient gitProcessClient,
    ILogger<GitRepositoryConnectorModule> logger) : IConfigurationModule
{
    private const string ModuleOptionKey = "connectors.git";

    public ModuleMetadata Metadata => IModule.Meta("connectors.git", GlobalPipelineModuleKinds.Configuration, priority: -100);

    public async Task Run(CancellationToken cancellationToken)
    {
        IRootConfigSection rootConfig = configProvider.Current;
        List<IFileConfigSection> files = [.. rootConfig.Files];

        foreach (IFileConfigSection file in files)
        {
            cancellationToken.ThrowIfCancellationRequested();

            GitFetcherFileSection? section = TryReadSection(file.Options);
            if (section is null)
            {
                continue;
            }

            foreach (GitRepositoryFetchConfig repository in section.Repositories
                         .OrderBy(x => x.Id, StringComparer.Ordinal)
                         .ThenBy(x => x.Repository, StringComparer.Ordinal))
            {
                cancellationToken.ThrowIfCancellationRequested();

                string repositoryUrl = BuildRepositoryUrl(repository);
                string relativeTarget = GetRelativeTargetPath(repository);
                string absoluteTarget = compiledWorkingFolder.Combine(relativeTarget);

                GitMaterializationResult result = await gitProcessClient.MaterializeAsync(
                    new GitMaterializationRequest(
                        repositoryUrl,
                        absoluteTarget,
                        repository.Branch,
                        repository.Refresh,
                        repository.Depth),
                    cancellationToken);

                logger.LogInformation(
                    "Git connector materialized repository {Repository} into {TargetPath} (cloned={Cloned}, updated={Updated})",
                    repository.Repository,
                    result.TargetPath,
                    result.Cloned,
                    result.Updated);

                string[] includes = PrefixPatterns(absoluteTarget, repository.Includes, defaultPattern: "**/*");
                string[] excludes = PrefixPatterns(absoluteTarget, repository.Excludes, defaultPattern: null);
                string[] tags = BuildTags(repository);

                if (!ContainsMatchingFileEntry(rootConfig, includes, excludes, tags))
                {
                    rootConfig.AddFile(includes, excludes, [], tags, null);
                }
            }
        }
    }

    private static GitFetcherFileSection? TryReadSection(JsonElement? options)
    {
        if (options is null)
        {
            return null;
        }

        JsonElement value = options.Value;
        return value.ValueKind != JsonValueKind.Object
            ? null
            : !value.TryGetProperty(ModuleOptionKey, out JsonElement moduleSection)
            ? null
            : moduleSection.Deserialize<GitFetcherFileSection>();
    }

    private static string BuildRepositoryUrl(GitRepositoryFetchConfig repository)
    {
        string raw = repository.Repository.Trim();
        if (Uri.TryCreate(raw, UriKind.Absolute, out Uri? absoluteUri))
        {
            string absolute = absoluteUri.ToString().TrimEnd('/');
            return absolute.EndsWith(".git", StringComparison.OrdinalIgnoreCase) ? absolute : $"{absolute}.git";
        }

        throw new InvalidOperationException("Repository value is not a valid absolute URI: " + repository.Repository);
    }

    private static string GetRelativeTargetPath(GitRepositoryFetchConfig repository)
    {
        if (!string.IsNullOrWhiteSpace(repository.Target))
        {
            return NormalizePath(repository.Target);
        }

        string normalizedRepository = GetRepositoryPathFragment(repository);

        return NormalizePath(Path.Combine("externals", "git", normalizedRepository.Replace('/', Path.DirectorySeparatorChar)));
    }

    private static string GetRepositoryPathFragment(GitRepositoryFetchConfig repository)
    {
        string raw = repository.Repository.Trim();
        if (Uri.TryCreate(raw, UriKind.Absolute, out Uri? absoluteUri))
        {
            List<string> segments = [absoluteUri.Host];
            segments.AddRange(absoluteUri.AbsolutePath
                .Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(SanitizePathSegment));

            if (segments.Count == 0)
            {
                return "repository";
            }

            string combined = string.Join('/', segments.Where(segment => !string.IsNullOrWhiteSpace(segment)));
            return combined;
        }

        string normalizedRepository = raw.Trim('/').Replace('\\', '/');
        return normalizedRepository;
    }

    private static string SanitizePathSegment(string value)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();
        char[] sanitized = [.. value.Select(ch => invalidChars.Contains(ch) ? '-' : ch)];

        return new string(sanitized);
    }

    private static string[] PrefixPatterns(string relativeTarget, string[]? patterns, string? defaultPattern)
    {
        string[] normalizedPatterns = patterns is { Length: > 0 }
            ? patterns
            : string.IsNullOrWhiteSpace(defaultPattern) ? [] : [defaultPattern];

        return [.. normalizedPatterns
            .Select(pattern => CombineGlob(relativeTarget, pattern))
            .OrderBy(pattern => pattern, StringComparer.Ordinal)];
    }

    private static string[] BuildTags(GitRepositoryFetchConfig repository)
    {
        List<string> tags =
        [
            "source:git"
        ];
        tags.AddRange(repository.Tags ?? []);

        return [.. tags
            .Where(tag => !string.IsNullOrWhiteSpace(tag))
            .Distinct(StringComparer.Ordinal)
            .OrderBy(tag => tag, StringComparer.Ordinal)];
    }

    private static bool ContainsMatchingFileEntry(IRootConfigSection rootConfig, string[] includes, string[] excludes, string[] tags)
    {
        return rootConfig.Files.Any(file =>
            file.Options is null
            && file.Includes.SequenceEqual(includes, StringComparer.Ordinal)
            && file.Excludes.SequenceEqual(excludes, StringComparer.Ordinal)
            && file.Tags.SequenceEqual(tags, StringComparer.Ordinal));
    }

    private static string CombineGlob(string relativeTarget, string pattern)
    {
        string normalizedTarget = NormalizePath(relativeTarget);
        string normalizedPattern = NormalizePath(pattern);
        return string.IsNullOrWhiteSpace(normalizedPattern)
            ? normalizedTarget
            : $"{normalizedTarget}/{normalizedPattern}".Replace("//", "/", StringComparison.Ordinal);
    }

    private static string NormalizePath(string path)
    {
        return path.Replace('\\', '/').Trim('/');
    }
}
