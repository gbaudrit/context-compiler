using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Security.Modules.Guards.Artifacts;

/// <summary>
/// Security guard module that scans output artifacts for security threats before deployment.
/// Detects suspicious patterns, injection attempts, hardcoded secrets, and untrusted external calls.
/// Marks unsafe artifacts for exclusion from deployment.
/// </summary>
public sealed class ArtifactSecurityGuardModule(
    ILogger<ArtifactSecurityGuardModule> logger,
    IOutput output) : IGlobalPipelineModule
{
    private static readonly string[] DangerousPatterns =
    [
        "eval(",
        "exec(",
        "subprocess",
        "os.system",
        "shell=True",
        "process.start",
        "ProcessStartInfo",
        "cmd.exe",
        "powershell.exe",
        "rm -rf",
        "rmdir /s"
    ];

    private static readonly string[] SecretPatterns =
    [
        "password=",
        "secret=",
        "api_key=",
        "apikey=",
        "token=",
        "credentials="
    ];

    private static readonly string[] SuspiciousKeywords =
    [
        "exfiltrate",
        "backdoor",
        "malware",
        "trojan",
        "ransomware",
        "keylogger",
        "stealer"
    ];

    private static readonly string[] TrustedDomains =
    [
        "github.com",
        "githubusercontent.com",
        "anthropic.com",
        "microsoft.com"
    ];

    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "security.guard.artifacts",
        GlobalPipelineModuleKinds.ArtifactValidation,
        priority: 2000
    );

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting security scan of output artifacts...");

        IReadOnlyList<IOutputArtifact> artifacts = output.Artifacts;

        // Scan artifacts that should be validated (Skills, Tools, Configuration)
        List<IOutputArtifact> scannableArtifacts = [.. artifacts.Where(a =>
            a.Category == ArtifactCategory.Skill ||
            a.Category == ArtifactCategory.Tool ||
            a.Category == ArtifactCategory.Configuration)];

        int scannedFiles = 0;
        int threatsFound = 0;
        int artifactsExcluded = 0;

        // Group artifacts by category and identifier (e.g., skillId, toolId) for batch exclusion
        Dictionary<string, List<IOutputArtifact>> artifactGroups = [];
        foreach (IOutputArtifact artifact in scannableArtifacts)
        {
            // Try to get identifier (skillId, toolId, etc.)
            string? identifier = artifact.Metadata.TryGetValue("skillId", out string? skillId) ? skillId
                : artifact.Metadata.TryGetValue("toolId", out string? toolId) ? toolId
                : artifact.Metadata.TryGetValue("configId", out string? configId) ? configId
                : null;

            if (identifier != null)
            {
                string groupKey = $"{artifact.Category}:{identifier}";
                if (!artifactGroups.TryGetValue(groupKey, out List<IOutputArtifact>? list))
                {
                    list = [];
                    artifactGroups[groupKey] = list;
                }
                list.Add(artifact);
            }
        }

        foreach (KeyValuePair<string, List<IOutputArtifact>> group in artifactGroups)
        {
            string groupKey = group.Key;
            List<IOutputArtifact> groupArtifacts = group.Value;
            bool hasThreats = false;

            foreach (IOutputArtifact artifact in groupArtifacts)
            {
                if (!artifact.Metadata.TryGetValue("sourcePath", out string? sourcePath) || !File.Exists(sourcePath))
                {
                    continue;
                }

                // Only scan text-based files
                string extension = Path.GetExtension(sourcePath).ToLowerInvariant();
                if (!IsTextFile(extension))
                {
                    continue;
                }

                try
                {
                    string content = File.ReadAllText(sourcePath);
                    scannedFiles++;

                    List<SecurityThreat> threats = ScanContent(content);

                    if (threats.Count > 0)
                    {
                        hasThreats = true;
                        threatsFound += threats.Count;

                        foreach (SecurityThreat threat in threats)
                        {
                            logger.LogWarning(
                                "Security threat in {GroupKey}, file {File}: [{Type}] {Description}",
                                groupKey,
                                Path.GetFileName(sourcePath),
                                threat.Type,
                                threat.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to scan file {File} for {GroupKey}", sourcePath, groupKey);
                }
            }

            // Mark all artifacts in this group as excluded if threats found
            if (hasThreats)
            {
                logger.LogError("{GroupKey} contains security threats - marking for exclusion", groupKey);

                foreach (IOutputArtifact artifact in groupArtifacts)
                {
                    // Update metadata to mark as excluded
                    if (artifact.Metadata is Dictionary<string, string> metadata)
                    {
                        metadata["excluded"] = "true";
                        metadata["exclusionReason"] = "security-threats";
                        artifactsExcluded++;
                    }
                }
            }
        }

        logger.LogInformation(
            "Security scan complete: scanned {ScannedFiles} files, found {ThreatsFound} threats, excluded {ExcludedArtifacts} artifacts",
            scannedFiles,
            threatsFound,
            artifactsExcluded);

        return context.Success();
    }

    private static bool IsTextFile(string extension)
    {
        return extension switch
        {
            ".md" or ".txt" or ".json" or ".js" or ".ts" or ".py" or
            ".yaml" or ".yml" or ".sh" or ".bash" or ".ps1" or
            ".cs" or ".java" or ".go" or ".rs" or ".rb" or ".php" => true,
            _ => false
        };
    }

    private static List<SecurityThreat> ScanContent(string content)
    {
        List<SecurityThreat> threats = [];
        string[] lines = content.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            int lineNumber = i + 1;
            string lineLower = line.ToLowerInvariant();

            // Check for dangerous patterns
            foreach (string pattern in DangerousPatterns)
            {
                if (lineLower.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                {
                    threats.Add(new SecurityThreat(
                        Type: "dangerous-code",
                        Description: $"Dangerous pattern '{pattern}' detected at line {lineNumber}",
                        Line: lineNumber
                    ));
                }
            }

            // Check for hardcoded secrets (case-sensitive for better precision)
            foreach (string secretPattern in SecretPatterns)
            {
                if (line.Contains(secretPattern, StringComparison.OrdinalIgnoreCase) &&
                    (line.Contains('\"') || line.Contains('\'')))
                {
                    threats.Add(new SecurityThreat(
                        Type: "hardcoded-secret",
                        Description: $"Potential hardcoded secret detected at line {lineNumber}",
                        Line: lineNumber
                    ));
                }
            }

            // Check for external URLs (not whitelisted)
            if (lineLower.Contains("http://", StringComparison.Ordinal) || lineLower.Contains("https://", StringComparison.Ordinal))
            {
                bool isTrusted = false;
                foreach (string domain in TrustedDomains)
                {
                    if (lineLower.Contains(domain, StringComparison.OrdinalIgnoreCase))
                    {
                        isTrusted = true;
                        break;
                    }
                }

                if (!isTrusted)
                {
                    threats.Add(new SecurityThreat(
                        Type: "external-url",
                        Description: $"Untrusted external URL detected at line {lineNumber}",
                        Line: lineNumber
                    ));
                }
            }

            // Check for suspicious keywords
            foreach (string keyword in SuspiciousKeywords)
            {
                if (lineLower.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    threats.Add(new SecurityThreat(
                        Type: "suspicious-keyword",
                        Description: $"Suspicious keyword '{keyword}' found at line {lineNumber}",
                        Line: lineNumber
                    ));
                }
            }
        }

        return threats;
    }

    private sealed record SecurityThreat(
        string Type,
        string Description,
        int Line
    );
}
