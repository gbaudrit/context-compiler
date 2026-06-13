using System.Xml.Linq;

using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Prepare.Modules.DotNet;

public sealed class DotNetProjectAnalyzer(IFileSystem fileSystem) : IDotNetProjectAnalyzer
{
#pragma warning disable IDE0028
    private static readonly HashSet<string> TestPackageIds = new(StringComparer.OrdinalIgnoreCase)
    {
        "Microsoft.NET.Test.Sdk",
        "MSTest",
        "MSTest.TestAdapter",
        "MSTest.TestFramework",
        "xunit",
        "xunit.runner.visualstudio",
        "NUnit",
        "NUnit3TestAdapter",
    };
#pragma warning restore IDE0028

    public static bool HasDotNetSignals(ProjectInventory inventory)
    {
        return inventory.Extensions.Any(x => string.Equals(x, ".csproj", StringComparison.OrdinalIgnoreCase))
            || inventory.Extensions.Any(x => string.Equals(x, ".sln", StringComparison.OrdinalIgnoreCase))
            || inventory.Files.Any(IsDotNetMarker);
    }

    public Task<DotNetAnalysis> AnalyzeAsync(Uri sourceUri, ProjectInventory inventory, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(sourceUri);
        ArgumentNullException.ThrowIfNull(inventory);
        cancellationToken.ThrowIfCancellationRequested();

        string rootPath = sourceUri.IsFile ? sourceUri.LocalPath : sourceUri.OriginalString;
        List<string> diagnostics = [];
        List<DotNetProject> projects = [];

        foreach (string relativeProjectPath in inventory.Files.Where(x => x.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)))
        {
            cancellationToken.ThrowIfCancellationRequested();
            string fullPath = Path.Combine(rootPath, relativeProjectPath);

            try
            {
                projects.Add(ReadProject(rootPath, fullPath));
            }
            catch (Exception ex)
            {
                diagnostics.Add($"{relativeProjectPath}: {ex.Message}");
            }
        }

        List<string> solutions = [.. inventory.Files
            .Where(x => x.EndsWith(".sln", StringComparison.OrdinalIgnoreCase))
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];

        List<string> cpmFiles = [.. inventory.Files
            .Where(x => string.Equals(Path.GetFileName(x), "Directory.Packages.props", StringComparison.OrdinalIgnoreCase))
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];

        List<string> buildFiles = [.. inventory.Files
            .Where(IsBuildFile)
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];

        List<string> frameworks = [.. projects
            .SelectMany(x => x.TargetFrameworks)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];

        DotNetAnalysis analysis = new()
        {
            Detected = HasDotNetSignals(inventory),
            Solutions = solutions,
            Projects = [.. projects.OrderBy(x => x.Path, StringComparer.OrdinalIgnoreCase)],
            CentralPackageManagement = new CentralPackageManagement
            {
                Detected = cpmFiles.Count > 0,
                Files = cpmFiles,
            },
            BuildFiles = buildFiles,
            Summary = new DotNetSummary
            {
                ProjectCount = projects.Count,
                TestProjectCount = projects.Count(x => x.IsTestProject),
                TargetFrameworks = frameworks,
                PackageCount = projects.SelectMany(x => x.PackageReferences).Select(x => x.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count(),
            },
            Diagnostics = diagnostics,
        };

        return Task.FromResult(analysis);
    }

    private DotNetProject ReadProject(string rootPath, string fullPath)
    {
        XDocument document;
        using (Stream stream = fileSystem.OpenRead(fullPath))
        {
            document = XDocument.Load(stream, LoadOptions.None);
        }

        XElement root = document.Root ?? throw new InvalidOperationException("Project XML root is missing.");
        List<string> targetFrameworks = ReadTargetFrameworks(root);
        List<DotNetPackageReference> packageReferences = ReadPackageReferences(root);

        bool isTestProject = root.Descendants()
            .Any(x => string.Equals(x.Name.LocalName, "IsTestProject", StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.Value.Trim(), "true", StringComparison.OrdinalIgnoreCase))
            || packageReferences.Any(x => TestPackageIds.Contains(x.Id));

        return new DotNetProject
        {
            Path = Normalize(Path.GetRelativePath(rootPath, fullPath)),
            Sdk = root.Attribute("Sdk")?.Value,
            TargetFrameworks = targetFrameworks,
            OutputType = root.Descendants().FirstOrDefault(x => string.Equals(x.Name.LocalName, "OutputType", StringComparison.OrdinalIgnoreCase))?.Value.Trim(),
            PackageReferences = packageReferences,
            ProjectReferences = [.. root.Descendants()
                .Where(x => string.Equals(x.Name.LocalName, "ProjectReference", StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Attribute("Include")?.Value)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => Normalize(x!))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)],
            IsTestProject = isTestProject,
        };
    }

    private static List<string> ReadTargetFrameworks(XElement root)
    {
        IEnumerable<string> values = root.Descendants()
            .Where(x => string.Equals(x.Name.LocalName, "TargetFramework", StringComparison.OrdinalIgnoreCase)
                || string.Equals(x.Name.LocalName, "TargetFrameworks", StringComparison.OrdinalIgnoreCase))
            .SelectMany(x => x.Value.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

        return [.. values.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase)];
    }

    private static List<DotNetPackageReference> ReadPackageReferences(XElement root)
    {
        return [.. root.Descendants()
            .Where(x => string.Equals(x.Name.LocalName, "PackageReference", StringComparison.OrdinalIgnoreCase))
            .Select(x => new DotNetPackageReference
            {
                Id = x.Attribute("Include")?.Value ?? x.Attribute("Update")?.Value ?? string.Empty,
                Version = x.Attribute("Version")?.Value
                    ?? x.Elements().FirstOrDefault(e => string.Equals(e.Name.LocalName, "Version", StringComparison.OrdinalIgnoreCase))?.Value.Trim(),
            })
            .Where(x => !string.IsNullOrWhiteSpace(x.Id))
            .OrderBy(x => x.Id, StringComparer.OrdinalIgnoreCase)];
    }

    private static bool IsDotNetMarker(string path)
    {
        string fileName = Path.GetFileName(path);
        return string.Equals(fileName, "global.json", StringComparison.OrdinalIgnoreCase)
            || string.Equals(fileName, "Directory.Build.props", StringComparison.OrdinalIgnoreCase)
            || string.Equals(fileName, "Directory.Packages.props", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsBuildFile(string path)
    {
        string fileName = Path.GetFileName(path);
        return string.Equals(fileName, "Directory.Build.props", StringComparison.OrdinalIgnoreCase)
            || string.Equals(fileName, "Directory.Build.targets", StringComparison.OrdinalIgnoreCase)
            || string.Equals(fileName, "global.json", StringComparison.OrdinalIgnoreCase)
            || string.Equals(fileName, "nuget.config", StringComparison.OrdinalIgnoreCase);
    }

    private static string Normalize(string path)
    {
        return path.Replace('\\', '/');
    }
}
