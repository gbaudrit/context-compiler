using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.GlobalPipeline.PrompComposer
{
    internal sealed class ViewsPromptComposer(IOutput output, ICtxcConfigProvider ctxcConfig, IPluginRegistry plugins, IReasoningIr ir) : IPromptComposerPlugin
    {
        public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.prompt.composer.views", GlobalPipelinePluginKinds.PromptComposer, priority: 10);

        public async Task Run(CancellationToken cancellationToken)
        {
            List<IViewResult> views = [];
            foreach (IViewPlugin? v in plugins.Views.OrderBy(v => v.Metadata.Priority))
            {
                views.AddRange(await v.BuildAsync(new ViewContext(ctxcConfig.Current.Views, ir), cancellationToken));
            }
            views.ForEach(v =>
            {
                output.AddArtifact((builder) =>
                {
                    return builder.WithFileName(v.Filename)
                                  .WithContent(v.Content);
                });
            });
        }
    }
}
