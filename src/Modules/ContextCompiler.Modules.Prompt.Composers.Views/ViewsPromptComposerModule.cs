using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Views;

public sealed class ViewsPromptComposerModule(IPrompt prompt, IConfigProvider ctxcConfig, IModulesRegistry modules, IReasoningIr ir) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("prompt.composers.views", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public async Task Run(CancellationToken cancellationToken)
    {
        List<IViewResult> views = [];
        foreach (IViewModule? v in modules.Views.OrderBy(v => v.Metadata.Priority))
        {
            views.AddRange(await v.BuildAsync(new ViewContext(ctxcConfig.Current.Views, ir), cancellationToken));
        }
        views.ForEach(v =>
        {
            prompt.AddArtifact((builder) =>
            {
                return builder.WithFileName(v.Filename)
                              .WithContent(v.Content)
                              .WithGeneratedBy(GetType());
            });
        });
    }
}
