using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Abstractions.Services.Prepare;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class ProjectScanner(
    IFileSystem fileSystem,
    ILogger<ProjectScanner> logger) : IProjectScanner
{
    private static readonly HashSet<string> ExcludedDirectoryNames = new(
        [
            ".git",
            ".svn",
            ".hg",
            ".vs",
            ".vscode",
            ".idea",
            ".ctxc",
            "bin",
            "obj",
            "node_modules",
            "dist",
            "build",
            "out",
            "target",
            "packages",
            ".gradle",
            ".mvn",
            "__pycache__",
            ".venv",
            "venv",
            "env",
        ],
        StringComparer.OrdinalIgnoreCase);

    private static readonly HashSet<string> KnownConfigFiles = new(
        [
            "package.json",
            "package-lock.json",
            "pnpm-lock.yaml",
            "yarn.lock",
            "tsconfig.json",
            "pom.xml",
            "build.gradle",
            "build.gradle.kts",
            "settings.gradle",
            "requirements.txt",
            "pyproject.toml",
            "Pipfile",
            "Gemfile",
            "Cargo.toml",
            "go.mod",
            "composer.json",
            "Dockerfile",
            "docker-compose.yml",
            "docker-compose.yaml",
            "Directory.Build.props",
            "Directory.Build.targets",
            "global.json",
            "nuget.config",
            "README.md",
            ".editorconfig",
            ".gitignore",
        ],
        StringComparer.OrdinalIgnoreCase);

    public Task<ProjectInventory> ScanAsync(Uri sourceUri, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(sourceUri);
        cancellationToken.ThrowIfCancellationRequested();

        string rootPath = sourceUri.IsFile ? sourceUri.LocalPath : sourceUri.OriginalString;
        logger.LogInformation("Scanning project at {RootPath}", rootPath);

        HashSet<string> extensions = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> directories = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> files = new([], StringComparer.OrdinalIgnoreCase);
        HashSet<string> technologies = new([], StringComparer.OrdinalIgnoreCase);
        int fileCount = 0;

        foreach (string filePath in fileSystem.EnumerateFiles(rootPath))
        {
            cancellationToken.ThrowIfCancellationRequested();

            string relative = Path.GetRelativePath(rootPath, filePath);
            if (IsInExcludedDirectory(relative))
            {
                continue;
            }

            fileCount++;

            string? ext = Path.GetExtension(filePath);
            if (!string.IsNullOrEmpty(ext))
            {
                _ = extensions.Add(ext);
            }

            string? directoryRelative = Path.GetDirectoryName(relative);
            if (!string.IsNullOrEmpty(directoryRelative))
            {
                _ = directories.Add(NormalizeDirectory(directoryRelative));
            }

            string fileName = Path.GetFileName(filePath);
            if (KnownConfigFiles.Contains(fileName))
            {
                _ = technologies.Add(fileName);
            }

            _ = files.Add(Path.Combine(directoryRelative ?? "", fileName));
        }

        ProjectInventory inventory = new()
        {
            Extensions = [.. extensions.OrderBy(e => e, StringComparer.OrdinalIgnoreCase)],
            Directories = [.. directories.OrderBy(d => d, StringComparer.OrdinalIgnoreCase)],
            Files = [.. files.OrderBy(d => d, StringComparer.OrdinalIgnoreCase)],
            Technologies = [.. technologies.OrderBy(t => t, StringComparer.OrdinalIgnoreCase)],
            FileCount = fileCount,
        };

        logger.LogInformation(
            "Scan complete: {FileCount} files, {ExtensionCount} extensions, {DirectoryCount} directories, {TechnologyCount} technologies",
            inventory.FileCount,
            inventory.Extensions.Count,
            inventory.Directories.Count,
            inventory.Technologies.Count);

        return Task.FromResult(inventory);
    }

    private static bool IsInExcludedDirectory(string relativePath)
    {
        foreach (string segment in relativePath.Split([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar], StringSplitOptions.RemoveEmptyEntries))
        {
            if (ExcludedDirectoryNames.Contains(segment))
            {
                return true;
            }
        }
        return false;
    }

    private static string NormalizeDirectory(string directoryRelative)
    {
        return directoryRelative.Replace('\\', '/');
    }
}
