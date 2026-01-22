using System.Text.Json;

using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class HealthOutput(
        IReasoningIr ir,
        IGuardian guardian,
        IViewsProvider viewsProvider,
        IOutput output) : IOutputArtifactComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.health", PluginKinds.Output, priority: 10);

        private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

        public ValueTask Compose(CancellationToken cancellationToken)
        {
            var health = new
            {
                fragments = ir.Fragments.Count,
                findings = guardian.Findings.Count,
                views = viewsProvider.Views.Count,
                score = Math.Max(0, 100 - guardian.Findings.Count * 5)
            };

            output.AddArtifact(builder =>
            {
                return builder.WithFileName("context.health.json")
                              .WithContent(JsonSerializer.Serialize(health, jsonSerializerOptions));
            });

            return ValueTask.CompletedTask;
        }

    }
}
