using System.Text.Json;
using System.Text.Json.Serialization;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Prepare.Modules.DotNet;

public sealed class DotNetProjectAnalysisModule(
    IDotNetProjectAnalyzer analyzer,
    [FromKeyedServices(StoreKeys.Prepare)] IStore prepareStore,
    ILogger<DotNetProjectAnalysisModule> logger) : IPreparePipelineModule
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.dotnet.analysis", PreparePipelineModuleKinds.ProjectClassification, priority: 100);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Inventory is null)
        {
            return await context.Failure("Inventory must be available before .NET analysis.");
        }

        if (!DotNetProjectAnalyzer.HasDotNetSignals(context.Inventory))
        {
            logger.LogInformation("Skipping .NET prepare analysis: no .NET signal detected.");
            return await context.Success();
        }

        DotNetAnalysis analysis = await analyzer.AnalyzeAsync(context.Request.SourceUri, context.Inventory, cancellationToken);
        await prepareStore.Init();
        await prepareStore.Container.GetResource("dotnet.analysis.json")
            .WriteAllText(JsonSerializer.Serialize(analysis, JsonOptions), cancellationToken);

        return await context.Success();
    }
}
