using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Pipelines.Document;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Document;

public static class DependencyInjection
{

    public static IServiceCollection AddDocumentPipeline(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IDocumentPipelineRunner, DocumentPipelineRunner>()
            .AddTransient<IDataEnvelopeBuilder, DataEnvelopeBuilder>()
            .AddTransient<IDataPartBuilder, DataPartBuilder>()
            .AddTransient<IDocumentContextPatchBuilder, DocumentContextPatchBuilder>()
            .AddSingleton<IDocumentContextBuilder, DocumentContextBuilder>()
            .AddSingleton<IDocumentContextPatcher, DocumentContextPatcher>()
            .AddTransient<IDocumentContextDataBuilder, DocumentContextDataBuilder>();
    }

}
