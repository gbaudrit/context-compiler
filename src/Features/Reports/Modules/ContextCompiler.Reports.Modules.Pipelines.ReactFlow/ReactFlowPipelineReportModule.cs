using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Events;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Module that generates interactive React Flow pipeline visualization reports.
/// </summary>
internal sealed class ReactFlowPipelineReportModule(
    PipelineEventCollector eventCollector,
    IOutput output,
    ILogger<ReactFlowPipelineReportModule> logger) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta(
        "reports.pipelines.reactflow",
        GlobalPipelineModuleKinds.ReportComposition,
        priority: 900);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyList<IPipelineEvent> events = eventCollector.GetEvents();

        if (events.Count == 0)
        {
            logger.LogInformation("No pipeline events collected, skipping React Flow report generation");
            return context.Success();
        }

        logger.LogInformation("Generating React Flow pipeline report from {EventCount} events", events.Count);

        try
        {
            // Convert pipeline events to JSON
            string pipelineDataJson = PipelineDataConverter.ConvertToJson(events);

            logger.LogDebug("Pipeline data JSON size: {Size} bytes", pipelineDataJson.Length);

            // Get the react-app path relative to this module
            string? moduleDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            if (string.IsNullOrEmpty(moduleDirectory))
            {
                logger.LogError("Could not determine module directory");
                return context.Success();
            }

            logger.LogInformation("Module assembly location: {Path}", moduleDirectory);

            // The module assembly is in lib/net10.0/, but assets are at the package root
            // Structure after NuGet extraction:
            // {package-root}/
            //   lib/net10.0/Module.dll  <- moduleDirectory is here
            //   contentFiles/any/any/react-app/dist/
            //
            // So we need to go up 2 levels to reach package root
            string? packageRoot = Directory.GetParent(moduleDirectory)?.Parent?.FullName;

            logger.LogInformation("Package root (2 levels up): {Path}", packageRoot ?? "null");

            // Try multiple paths following NuGet conventions
            string[] possibleReactAppPaths = packageRoot is not null
                ? [
                    Path.Combine(packageRoot, "contentFiles", "any", "any", "react-app"),  // NuGet contentFiles
                    Path.Combine(packageRoot, "module-assets", "react-app"),               // Custom convention
                    Path.Combine(packageRoot, "react-app"),                                // Legacy/fallback
                    Path.Combine(moduleDirectory, "react-app")                             // Dev environment
                  ]
                : [Path.Combine(moduleDirectory, "react-app")];

            logger.LogInformation("Trying {Count} possible paths for react-app", possibleReactAppPaths.Length);
            foreach (string path in possibleReactAppPaths)
            {
                bool exists = Directory.Exists(path);
                logger.LogInformation("  - {Path}: {Exists}", path, exists ? "EXISTS" : "NOT FOUND");
            }

            // In development, the react-app is in the source directory
            string? reactAppPath = possibleReactAppPaths.FirstOrDefault(Directory.Exists);

            // If react-app doesn't exist in any standard location, try to find it in the source tree (dev mode)
            if (reactAppPath is null)
            {
                logger.LogDebug("React app not found in standard locations, searching source tree...");

                // Try to find the source directory
                string? currentDir = moduleDirectory;
                while (currentDir != null && !File.Exists(Path.Combine(currentDir, "ContextCompiler.Reports.Modules.Pipelines.ReactFlow.csproj")))
                {
                    currentDir = Directory.GetParent(currentDir)?.FullName;
                }

                if (currentDir != null)
                {
                    logger.LogDebug("Found source directory at {Path}", currentDir);
                    string sourcePath = Path.Combine(currentDir, "react-app");
                    if (Directory.Exists(sourcePath))
                    {
                        logger.LogInformation("Using React app from source tree: {Path}", sourcePath);
                        reactAppPath = sourcePath;
                    }
                }
            }
            else
            {
                logger.LogInformation("Found React app at {Path}", reactAppPath);
            }

            if (reactAppPath is null)
            {
                logger.LogError("React app directory not found. Tried paths: {Paths}",
                    string.Join(", ", possibleReactAppPaths));
                logger.LogWarning("Generating fallback JSON report instead");

                output.AddArtifact(builder =>
                {
                    return builder.WithFileName("pipeline-report-reactflow-data.json")
                                  .WithContent(pipelineDataJson)
                                  .WithGeneratedBy(GetType());
                });

                return context.Success();
            }

            logger.LogInformation("Using React app at {Path}", reactAppPath);

            // Generate HTML with embedded data
            string html = ReactFlowHtmlGenerator.GenerateHtml(
                pipelineDataJson,
                logger,
                reactAppPath);

            output.AddArtifact(builder =>
            {
                return builder.WithFileName("pipeline-report-reactflow.html")
                              .WithContent(html)
                              .WithGeneratedBy(GetType());
            });

            logger.LogInformation("React Flow pipeline report generated successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to generate React Flow pipeline report");
            // Don't fail the pipeline, just skip the report
        }

        return context.Success();
    }
}
