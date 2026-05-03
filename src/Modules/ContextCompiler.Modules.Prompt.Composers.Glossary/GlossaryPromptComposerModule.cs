using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;

namespace ContextCompiler.Modules.Prompt.Composers.Glossary;

public sealed class GlossaryPromptComposerModule(IPrompt prompt, IGlossaryTermBuilder termBuilder, IConfigProvider ctxcConfig) : IPromptComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.composers.glossary", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken cancellationToken)
    {
        List<IGlossaryTerm> list = ctxcConfig.Current.Context.Glossary?
            .Select(kv => termBuilder.InitNew().WithTerm(kv.Key).WithDefinition(kv.Value).Build())
            .ToList() ?? [];
        prompt.Glossary = [.. list];
        return context.Success();
    }
}
