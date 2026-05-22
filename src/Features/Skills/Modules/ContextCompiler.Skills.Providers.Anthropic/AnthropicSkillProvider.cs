using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

namespace ContextCompiler.Skills.Providers.Anthropic;

public sealed class AnthropicSkillProvider(
    ISkillsLoadConfigProvider configProvider,
    IWorkingFolder workingFolder) : ISkillProvider
{
    public const string Id = "anthropic-agent-skills";
    private const string Owner = "anthropics";
    private const string Repository = "skills";
    private const string DefaultRef = "main";
    private static readonly HttpClient Http = CreateHttpClient();
    private static readonly IReadOnlyDictionary<string, string[]> SkillBundles = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
    {
        ["document-skills"] = ["xlsx", "docx", "pptx", "pdf"],
        ["example-skills"] =
        [
            "algorithmic-art",
            "brand-guidelines",
            "canvas-design",
            "claude-api",
            "doc-coauthoring",
            "frontend-design",
            "internal-comms",
            "mcp-builder",
            "skill-creator",
            "slack-gif-creator",
            "theme-factory",
            "web-artifacts-builder",
            "webapp-testing"
        ]
    };

    public string ProviderId => Id;

    public async Task<IReadOnlyList<SkillDescriptor>> SearchAsync(SkillQuery query, CancellationToken cancellationToken)
    {
        string gitRef = GetGitRef(query.Filters);
        Uri uri = new($"https://api.github.com/repos/{Owner}/{Repository}/contents/skills?ref={Uri.EscapeDataString(gitRef)}");
        using HttpResponseMessage response = await Http.GetAsync(uri, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return [];
        }

        _ = response.EnsureSuccessStatusCode();
        await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        JsonDocument document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);

        List<SkillDescriptor> descriptors = [];
        foreach (string bundleId in SkillBundles.Keys)
        {
            if (!MatchesQuery(bundleId, query.Text))
            {
                continue;
            }

            descriptors.Add(new SkillDescriptor(
                new SkillReference(bundleId, ProviderId, gitRef),
                bundleId,
                $"Anthropic skill bundle containing {SkillBundles[bundleId].Length} skills.",
                gitRef,
                $"github:{Owner}/{Repository}/.claude-plugin/marketplace.json#{bundleId}@{gitRef}",
                true));
        }

        foreach (JsonElement item in document.RootElement.EnumerateArray())
        {
            if (!IsDirectory(item))
            {
                continue;
            }

            string skillId = item.GetProperty("name").GetString() ?? "";
            if (string.IsNullOrWhiteSpace(skillId))
            {
                continue;
            }

            if (!MatchesQuery(skillId, query.Text))
            {
                continue;
            }

            descriptors.Add(new SkillDescriptor(
                new SkillReference(skillId, ProviderId, gitRef),
                skillId,
                null,
                gitRef,
                $"github:{Owner}/{Repository}/skills/{skillId}@{gitRef}",
                true));
        }

        return [.. descriptors.OrderBy(x => x.Reference.Id, StringComparer.OrdinalIgnoreCase)];
    }

    public async Task<SkillDescriptor?> ResolveAsync(SkillReference reference, CancellationToken cancellationToken)
    {
        if (!reference.Provider.Equals(ProviderId, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        string gitRef = NormalizeVersion(reference.Version);
        if (SkillBundles.ContainsKey(reference.Id))
        {
            return new SkillDescriptor(
                reference with { Version = gitRef },
                reference.Id,
                $"Anthropic skill bundle containing {SkillBundles[reference.Id].Length} skills.",
                gitRef,
                $"github:{Owner}/{Repository}/.claude-plugin/marketplace.json#{reference.Id}@{gitRef}",
                true);
        }

        Uri skillUri = RawSkillUri(reference.Id, gitRef);
        using HttpResponseMessage response = await Http.GetAsync(skillUri, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        _ = response.EnsureSuccessStatusCode();
        string skillMarkdown = await response.Content.ReadAsStringAsync(cancellationToken);
        SkillFrontMatter frontMatter = ParseFrontMatter(skillMarkdown);

        return new SkillDescriptor(
            reference with { Version = gitRef },
            string.IsNullOrWhiteSpace(frontMatter.Name) ? reference.Id : frontMatter.Name,
            frontMatter.Description,
            gitRef,
            $"github:{Owner}/{Repository}/skills/{reference.Id}@{gitRef}",
            true);
    }

    public async Task<SkillPackage> FetchAsync(SkillDescriptor descriptor, CancellationToken cancellationToken)
    {
        string gitRef = NormalizeVersion(descriptor.Reference.Version ?? descriptor.ResolvedVersion);
        string skillId = descriptor.Reference.Id;
        string cacheRoot = ResolveWorkspacePath(configProvider.Current.CacheRoot);
        string compiledRoot = ResolveWorkspacePath(configProvider.Current.CompiledRoot);
        string safeRef = SanitizePathSegment(gitRef);
        string cachePath = Path.Combine(cacheRoot, ProviderId, skillId, safeRef);
        string compiledPath = compiledRoot;

        if (Directory.Exists(cachePath))
        {
            Directory.Delete(cachePath, true);
        }

        if (Directory.Exists(compiledPath))
        {
            Directory.Delete(compiledPath, true);
        }

        _ = Directory.CreateDirectory(cachePath);
        _ = Directory.CreateDirectory(compiledPath);

        bool isBundle = SkillBundles.TryGetValue(skillId, out string[]? bundleSkills);
        string[] skillsToExtract = isBundle && bundleSkills is not null
            ? bundleSkills
            : [skillId];

        await ExtractSkillsFromRepositoryZip(skillsToExtract, gitRef, cachePath, cancellationToken);
        if (isBundle)
        {
            CopyBundleSkills(cachePath, compiledPath);
        }
        else
        {
            CopyDirectory(cachePath, Path.Combine(compiledPath, skillId));
        }

        string compiledPackagePath = isBundle ? compiledPath : Path.Combine(compiledPath, skillId);
        string checksum = ComputeDirectoryChecksum(compiledPackagePath);
        IReadOnlyList<string> files =
        [
            .. Directory.EnumerateFiles(compiledPackagePath, "*", SearchOption.AllDirectories)
            .Select(path => Path.GetRelativePath(compiledPackagePath, path).Replace('\\', '/'))
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
        ];

        return new SkillPackage(descriptor, cachePath, compiledPackagePath, checksum, files);
    }

    private static HttpClient CreateHttpClient()
    {
        HttpClient http = new();
        http.DefaultRequestHeaders.UserAgent.ParseAdd("ContextCompiler-Skills-Anthropic/0.1");
        http.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
        return http;
    }

    private static string GetGitRef(IReadOnlyDictionary<string, string>? filters)
    {
        return filters is not null && filters.TryGetValue("ref", out string? value)
            ? NormalizeVersion(value)
            : DefaultRef;
    }

    private static string NormalizeVersion(string? version)
    {
        return string.IsNullOrWhiteSpace(version) || version.Equals("latest", StringComparison.OrdinalIgnoreCase)
            ? DefaultRef
            : version;
    }

    private static Uri RawSkillUri(string skillId, string gitRef)
    {
        string escapedRef = Uri.EscapeDataString(gitRef);
        string escapedSkillId = Uri.EscapeDataString(skillId);
        return new Uri($"https://raw.githubusercontent.com/{Owner}/{Repository}/{escapedRef}/skills/{escapedSkillId}/SKILL.md");
    }

    private static bool IsDirectory(JsonElement item)
    {
        return item.TryGetProperty("type", out JsonElement type)
            && type.GetString()?.Equals("dir", StringComparison.OrdinalIgnoreCase) == true;
    }

    private static bool MatchesQuery(string skillId, string? query)
    {
        return string.IsNullOrWhiteSpace(query)
            || skillId.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    private static async Task ExtractSkillsFromRepositoryZip(string[] skillIds, string gitRef, string destination, CancellationToken cancellationToken)
    {
        HashSet<string> found = [];
        Uri zipUri = new($"https://codeload.github.com/{Owner}/{Repository}/zip/{Uri.EscapeDataString(gitRef)}");
        using HttpResponseMessage response = await Http.GetAsync(zipUri, cancellationToken);
        _ = response.EnsureSuccessStatusCode();

        await using Stream zipStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using ZipArchive archive = new(zipStream, ZipArchiveMode.Read);

        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string? skillId = skillIds.FirstOrDefault(id => entry.FullName.Contains($"/skills/{id}/", StringComparison.Ordinal));
            if (skillId is null)
            {
                continue;
            }

            string skillPrefix = $"/skills/{skillId}/";
            int prefixIndex = entry.FullName.IndexOf(skillPrefix, StringComparison.Ordinal);
            if (prefixIndex < 0 || entry.FullName.EndsWith('/'))
            {
                continue;
            }

            _ = found.Add(skillId);
            string relativePath = entry.FullName[(prefixIndex + skillPrefix.Length)..];
            string skillRoot = skillIds.Length == 1 ? destination : Path.Combine(destination, "skills", skillId);
            string outputPath = Path.Combine(skillRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));
            _ = Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            entry.ExtractToFile(outputPath, true);
        }

        string[] missing = [.. skillIds.Except(found, StringComparer.OrdinalIgnoreCase)];
        if (missing.Length > 0)
        {
            throw new InvalidOperationException($"Skill(s) '{string.Join(", ", missing)}' were not found in {Owner}/{Repository}@{gitRef}.");
        }
    }

    private static SkillFrontMatter ParseFrontMatter(string markdown)
    {
        using StringReader reader = new(markdown);
        if (!string.Equals(reader.ReadLine(), "---", StringComparison.Ordinal))
        {
            return new SkillFrontMatter(null, null);
        }

        string? name = null;
        string? description = null;
        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            if (string.Equals(line.Trim(), "---", StringComparison.Ordinal))
            {
                break;
            }

            int separator = line.IndexOf(':', StringComparison.Ordinal);
            if (separator <= 0)
            {
                continue;
            }

            string key = line[..separator].Trim();
            string value = line[(separator + 1)..].Trim().Trim('"');
            if (key.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                name = value;
            }
            else if (key.Equals("description", StringComparison.OrdinalIgnoreCase))
            {
                description = value;
            }
        }

        return new SkillFrontMatter(name, description);
    }

    private string ResolveWorkspacePath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : Path.GetFullPath(Path.Combine(workingFolder.Path, path.Replace('/', Path.DirectorySeparatorChar)));
    }

    private static string ComputeDirectoryChecksum(string path)
    {
        using SHA256 sha = SHA256.Create();
        foreach (string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).OrderBy(x => x, StringComparer.OrdinalIgnoreCase))
        {
            string relativePath = Path.GetRelativePath(path, file).Replace('\\', '/');
            byte[] nameBytes = Encoding.UTF8.GetBytes(relativePath);
            _ = sha.TransformBlock(nameBytes, 0, nameBytes.Length, null, 0);

            byte[] content = File.ReadAllBytes(file);
            _ = sha.TransformBlock(content, 0, content.Length, null, 0);
        }

        _ = sha.TransformFinalBlock([], 0, 0);
        return Convert.ToBase64String(sha.Hash ?? []);
    }

    private static void CopyDirectory(string source, string destination)
    {
        foreach (string directory in Directory.EnumerateDirectories(source, "*", SearchOption.AllDirectories))
        {
            string relativeDirectory = Path.GetRelativePath(source, directory);
            _ = Directory.CreateDirectory(Path.Combine(destination, relativeDirectory));
        }

        foreach (string file in Directory.EnumerateFiles(source, "*", SearchOption.AllDirectories))
        {
            string relativeFile = Path.GetRelativePath(source, file);
            string destinationFile = Path.Combine(destination, relativeFile);
            _ = Directory.CreateDirectory(Path.GetDirectoryName(destinationFile)!);
            File.Copy(file, destinationFile, true);
        }
    }

    private static void CopyBundleSkills(string source, string destination)
    {
        string skillsRoot = Path.Combine(source, "skills");
        if (!Directory.Exists(skillsRoot))
        {
            throw new InvalidOperationException($"Bundle cache does not contain a skills folder: {skillsRoot}");
        }

        foreach (string skillDirectory in Directory.EnumerateDirectories(skillsRoot))
        {
            string skillId = Path.GetFileName(skillDirectory);
            CopyDirectory(skillDirectory, Path.Combine(destination, skillId));
        }
    }

    private static string SanitizePathSegment(string value)
    {
        StringBuilder builder = new(value.Length);
        foreach (char c in value)
        {
            _ = builder.Append(Path.GetInvalidFileNameChars().Contains(c) ? '_' : c);
        }

        return builder.ToString();
    }

    private sealed record SkillFrontMatter(string? Name, string? Description);
}
