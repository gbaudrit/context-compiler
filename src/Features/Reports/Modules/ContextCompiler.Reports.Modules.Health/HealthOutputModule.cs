using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Reports.Modules.Health;

public sealed class HealthOutputModule(
    ICompiledContext ir,
    IGuardian guardian,
    IViewsProvider viewsProvider,
    IOutput output) : ICompilePipelineModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("health.report", CompilePipelineModuleKinds.ReportComposition, priority: 10);

    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
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
