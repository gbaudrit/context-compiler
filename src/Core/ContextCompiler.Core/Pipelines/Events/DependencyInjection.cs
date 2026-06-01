using ContextCompiler.Abstractions.Pipelines.Events;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Events;

public static class DependencyInjection
{
    public static IServiceCollection AddPipelineEvents(this IServiceCollection services)
    {
        return services.AddSingleton<IPipelineEventPublisher, PipelineEventPublisher>();
    }
}
