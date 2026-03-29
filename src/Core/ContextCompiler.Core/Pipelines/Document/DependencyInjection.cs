using ContextCompiler.Abstractions.Pipelines.Document;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Pipelines.Document;

public static class DependencyInjection
{

    public static IServiceCollection AddDocumentPipeline(this IServiceCollection services)
    {
        // Register core services here
        _ = services.AddSingleton<IDocumentPipelineRunner, DocumentPipelineRunner>().AddTransient<IDataEnvelopeBuilder, DataEnvelopeBuilder>().AddTransient<IDataPartBuilder, DataPartBuilder>();

        return services
            .AddSingleton<IDocumentPass, BeginProcessDocumentPass>()
            .AddSingleton<IDocumentPass, DiscoveryScopeGuardsPass>()
            .AddSingleton<IDocumentPass, ReadScopeGuardsPass>()
            .AddSingleton<IDocumentPass, BuildCompositePartsPass>()
            .AddSingleton<IDocumentPass, FileMatchTagsPass>()
            .AddSingleton<IDocumentPass, ReadDocumentPass>()
            .AddSingleton<IDocumentPass, EndProcessDocumentPass>();
    }

}
