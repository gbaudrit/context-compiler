using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Reports.Modules.Health;

public sealed class HealthOutputModule(
    ICompiledContext ir,
    IGuardian guardian,
    IViewsProvider viewsProvider,
    IOutput output) : IGlobalPipelineModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("health.report", GlobalPipelineModuleKinds.ReportComposition, priority: 10);

    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        var health = new
        {
            fragments = ir.Fragments.Count,
            findings = guardian.Findings.Count,
            views = viewsProvider.Views.Count,
            score = Math.Max(0, 100 - (guardian.Findings.Count * 5))
        };

        output.AddArtifact(builder =>
        {
            return builder.WithName("context.health.json")
                          .InStore(StoreKeys.Reports)
                          .WithContent(JsonSerializer.Serialize(health, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());
        });

        return context.Success();
    }

}
