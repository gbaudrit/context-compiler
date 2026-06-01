using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Prompting.Pipelines.PromptComposition;

public static class DependencyInjection
{
    public static IServiceCollection AddPromptComposerPipeline(this IServiceCollection services)
    {
        services.TryAddEnumerable(ServiceDescriptor.Transient<IGlobalPipelineModule, PromptComposerPipeline>());
        return services
            .AddTransient<IPromptComposerRunContextBuilder, PromptComposerRunContextBuilder>()
            .AddTransient<IPromptComposerRunResultBuilder, PromptComposerRunResultBuilder>();
    }
}
