using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Models.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Abstractions.Storage;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Core.Pipelines.Prepare.Services;

internal sealed class PrepareReportRenderer(
    [FromKeyedServices(StoreKeys.Reports)] IStore reportsStore,
    ILogger<PrepareReportRenderer> logger) : IPrepareReportRenderer
{
    public async Task RenderAsync(
        PrepareRequest request,
        ProjectInventory inventory,
        ProjectClassification classification,
        PreparePlan plan,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(inventory);
        ArgumentNullException.ThrowIfNull(classification);
        ArgumentNullException.ThrowIfNull(plan);
        cancellationToken.ThrowIfCancellationRequested();

        await reportsStore.Init();

        StringBuilder sb = new();
        _ = sb.AppendLine("# Prepare Report");
        _ = sb.AppendLine();
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Source: `{request.SourceUri}`");
        if (!string.IsNullOrWhiteSpace(request.Goal))
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Goal: {request.Goal}");
        }
        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Description: {request.Description}");
        }
        _ = sb.AppendLine();

        _ = sb.AppendLine("## Inventory");
        _ = sb.AppendLine();
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Files: {inventory.FileCount}");
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Directories: {inventory.Directories.Count}");
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Extensions: {inventory.Extensions.Count}");
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- Known configuration files: {inventory.Technologies.Count}");
        _ = sb.AppendLine();

        AppendList(sb, "### Extensions", inventory.Extensions);
        AppendList(sb, "### Known configuration files", inventory.Technologies);

        _ = sb.AppendLine("## Classification");
        _ = sb.AppendLine();
        AppendList(sb, "### Technologies", classification.Technologies);
        AppendList(sb, "### Languages", classification.Languages);
        AppendList(sb, "### Frameworks", classification.Frameworks);

        _ = sb.AppendLine("## Plan");
        _ = sb.AppendLine();
        AppendList(sb, "### Recommended pipelines", plan.RecommendedPipelines);
        AppendList(sb, "### Recommended skills", plan.RecommendedSkills);
        AppendList(sb, "### Include patterns", plan.IncludePatterns);
        AppendList(sb, "### Exclude patterns", plan.ExcludePatterns);

        IStoreResource resource = reportsStore.Container.GetResource("prepare-report.md");
        await resource.WriteAllText(sb.ToString(), cancellationToken);
        logger.LogInformation("Wrote {Path}", resource.Uri.AbsolutePath);
    }

    private static void AppendList(StringBuilder sb, string heading, IReadOnlyCollection<string> items)
    {
        _ = sb.AppendLine(heading);
        _ = sb.AppendLine();
        if (items.Count == 0)
        {
            _ = sb.AppendLine("_None_");
        }
        else
        {
            foreach (string item in items)
            {
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- `{item}`");
            }
        }
        _ = sb.AppendLine();
    }
}
