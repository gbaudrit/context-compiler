using System.Globalization;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Ports;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Output.Modules.Artifacts.Writer;

public sealed class OutputArtifactsFilesWriterModule(IOutput output, IFileSystem fs, ILogger<OutputArtifactsFilesWriterModule> logger) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("artifacts.writer", GlobalPipelineModuleKinds.ArtifactPersistence, priority: 10);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        if (!output.Artifacts.Any())
        {
            logger.LogInformation("No output artifacts to write for output");
            return await context.Success();
        }

        int writtenCount = 0;
        int excludedCount = 0;
        Dictionary<string, (int excluded, string reason)> excludedByCategory = [];

        foreach (IOutputArtifact artifact in output.Artifacts)
        {
            // Check if artifact is marked for exclusion
            if (artifact.Metadata.TryGetValue("excluded", out string? excludedValue) &&
                bool.TryParse(excludedValue, out bool isExcluded) &&
                isExcluded)
            {
                string reason = artifact.Metadata.TryGetValue("exclusionReason", out string? reasonValue)
                    ? reasonValue
                    : "unknown";

                string categoryKey = artifact.Category.ToString();
                if (!excludedByCategory.TryGetValue(categoryKey, out (int, string) value))
                {
                    value = (0, reason);
                }
                excludedByCategory[categoryKey] = (value.Item1 + 1, reason);

                excludedCount++;
                logger.LogDebug("Excluded artifact: {Description} (Reason: {Reason})", artifact.Description, reason);
                continue;
            }

            // Write artifact to its designated location (determined by StoreResource)
            await artifact.StoreResource.WriteAllText(artifact.Content, cancellationToken);
            writtenCount++;

            logger.LogInformation("Wrote output artifact: {Uri}", artifact.StoreResource.Uri.AbsolutePath);
        }

        logger.LogInformation(
            "Artifacts writing complete: {Written} written, {Excluded} excluded",
            writtenCount,
            excludedCount);

        // Generate deployment report if there were exclusions
        if (excludedCount > 0)
        {
            GenerateDeploymentReport(writtenCount, excludedCount, excludedByCategory);
        }

        return await context.Success();
    }

    private void GenerateDeploymentReport(
        int written,
        int excluded,
        Dictionary<string, (int count, string reason)> excludedByCategory)
    {
        try
        {
            string reportPath = Path.Combine(output.Path, "artifacts.deployment.report.md");

            System.Text.StringBuilder report = new();
            _ = report.AppendLine("# Artifacts Deployment Report");
            _ = report.AppendLine();
            _ = report.AppendLine(CultureInfo.InvariantCulture, $"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
            _ = report.AppendLine();
            _ = report.AppendLine("## Summary");
            _ = report.AppendLine();
            _ = report.AppendLine(CultureInfo.InvariantCulture, $"- ✅ Written: {written} artifacts");
            _ = report.AppendLine(CultureInfo.InvariantCulture, $"- ❌ Excluded: {excluded} artifacts");
            _ = report.AppendLine();

            if (excludedByCategory.Count > 0)
            {
                _ = report.AppendLine("## Exclusions by Category");
                _ = report.AppendLine();

                foreach (KeyValuePair<string, (int count, string reason)> entry in excludedByCategory)
                {
                    _ = report.AppendLine(CultureInfo.InvariantCulture, $"### ❌ {entry.Key}");
                    _ = report.AppendLine(CultureInfo.InvariantCulture, $"- **Count**: {entry.Value.count} artifact(s)");
                    _ = report.AppendLine(CultureInfo.InvariantCulture, $"- **Reason**: {entry.Value.reason}");
                    _ = report.AppendLine();
                }
            }

            _ = report.AppendLine("---");
            _ = report.AppendLine();
            _ = report.AppendLine("*This report was generated automatically during the artifact persistence phase.*");

            File.WriteAllText(reportPath, report.ToString());
            logger.LogInformation("Deployment report generated: {ReportPath}", reportPath);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to generate deployment report");
        }
    }
}
