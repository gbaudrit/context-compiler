using System.Text.Json;

using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class HealthOutput(
        IReasoningIr ir,
        IGuardian guardian,
        IViewsProvider viewsProvider,
        IOutput output) : IOutputArtifactComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.health", GlobalPipelinePluginKinds.Output, priority: 10);

        private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

        public Task Run(CancellationToken cancellationToken)
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
                return builder.WithFileName("context.health.json")
                              .WithContent(JsonSerializer.Serialize(health, jsonSerializerOptions));
            });

            return Task.CompletedTask;
        }

    }
}
