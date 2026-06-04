using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Prompting.Abstractions.Prompt;

namespace ContextCompiler.Prompting.Modules.Composers.Glossary;

public sealed class GlossaryPromptComposerModule(IPrompt prompt, IGlossaryTermBuilder termBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("prompt.composers.glossary", CompilePipelineModuleKinds.OutputComposition, priority: 10);

    public Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        List<IGlossaryTerm> list = ctxcConfig.Current.Context.Glossary?
            .Select(kv => termBuilder.InitNew().WithTerm(kv.Key).WithDefinition(kv.Value).Build())
            .ToList() ?? [];
        prompt.Glossary = [.. list];
        return context.Success();
    }
}
