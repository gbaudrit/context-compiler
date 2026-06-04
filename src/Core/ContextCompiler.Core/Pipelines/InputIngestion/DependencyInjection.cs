using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Core.Pipelines.InputIngestion;

public static class DependencyInjection
{

    public static IServiceCollection AddInputIngestionPipeline(this IServiceCollection services)
    {
        // Register core services here
        services.TryAddEnumerable(ServiceDescriptor.Transient<ICompilePipelineModule, InputIngestionPipeline>());

        return services.AddTransient<IDataEnvelopeBuilder, DataEnvelopeBuilder>()
                       .AddTransient<IDataPartBuilder, DataPartBuilder>()
                       .AddTransient<IInputItemContextPatchBuilder, InputItemContextPatchBuilder>()
                       .AddSingleton<IInputItemContextBuilder, InputItemContextBuilder>()
                       .AddSingleton<IInputItemContextPatcher, InputItemContextPatcher>()
                       .AddTransient<IInputItemContextDataBuilder, InputItemContextDataBuilder>()
                       .AddTransient<IInputIngestionPipelineRunContextBuilder, InputIngestionPipelineRunContextBuilder>()
                       .AddTransient<IInputIngestionPipelineRunResultBuilder, InputIngestionPipelineRunResultBuilder>();
    }

}
