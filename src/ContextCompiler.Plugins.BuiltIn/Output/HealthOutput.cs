using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.Output
{
    internal sealed class HealthOutput(
        IReasoningIr ir,
        IOutputJsonArtifactWriter outputJsonArtifactWriter,
        IGuardian guardian,
        IViewsProvider viewsProvider) : IOutputPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.output.health", PluginKinds.Output, priority: 10);


        public Task Run(CancellationToken cancellationToken)
        {
            var health = new
            {
                fragments = ir.Fragments.Count,
                findings = guardian.Findings.Count,
                views = viewsProvider.Views.Count,
                score = Math.Max(0, 100 - guardian.Findings.Count * 5)
            };

            return outputJsonArtifactWriter.Write("context.health.json", health);
        }

    }
}
