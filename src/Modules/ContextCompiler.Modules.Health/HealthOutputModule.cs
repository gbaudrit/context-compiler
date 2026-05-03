using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Health;

public sealed class HealthOutputModule(
    IReasoningIr ir,
    IGuardian guardian,
    IViewsProvider viewsProvider,
    IPrompt prompt) : IOutputArtifactComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("health.report", GlobalPipelineModuleKinds.Output, priority: 10);

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

        prompt.AddArtifact(builder =>
        {
            return builder.WithFileName("context.health.json")
                          .WithContent(JsonSerializer.Serialize(health, jsonSerializerOptions))
                          .WithGeneratedBy(GetType());
        });

        return context.Success();
    }

}
