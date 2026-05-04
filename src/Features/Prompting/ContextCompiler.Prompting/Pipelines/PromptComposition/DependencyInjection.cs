using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

public static class DependencyInjection
{
    public static IServiceCollection AddPromptComposerPipeline(this IServiceCollection services)
    {
        return services
            .AddTransient<IGlobalPipelineModule, PromptComposerPipeline>()
            .AddTransient<IPromptComposerRunContextBuilder, PromptComposerRunContextBuilder>()
            .AddTransient<IPromptComposerRunResultBuilder, PromptComposerRunResultBuilder>();
    }
}
