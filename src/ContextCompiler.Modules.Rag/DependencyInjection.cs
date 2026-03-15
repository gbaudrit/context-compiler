using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Embeddings;
using ContextCompiler.Modules.Rag.Storage;

using Microsoft.Extensions.DependencyInjection;

using SmartComponents.LocalEmbeddings;

namespace ContextCompiler.Modules.Rag;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services
            .AddSingleton<LocalEmbedder>()
            .AddSingleton<IEmbeddingGenerator, LocalEmbeddingGenerator>()
            .AddSingleton<IRagStore, FileSystemRagStore>();
        //.AddSingleton<ISemanticSearchService, SemanticSearchService>();
    }
}
