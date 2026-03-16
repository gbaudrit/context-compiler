using System.Reflection;

using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Embeddings;
using ContextCompiler.Modules.Rag.Indexation;
using ContextCompiler.Modules.Rag.MCP;
using ContextCompiler.Modules.Rag.Search;
using ContextCompiler.Modules.Rag.Storage;
using ContextCompiler.Modules.Rag.Tokenizers;

using Microsoft.Extensions.DependencyInjection;

using SmartComponents.LocalEmbeddings;

namespace ContextCompiler.Modules.Rag;

public sealed class DependencyInjection : IDependencyInjection
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        string assemblyPath = Path.GetDirectoryName(typeof(DependencyInjection).Assembly.Location)!;
        string embeddingsPath = Path.Combine(assemblyPath, "..", "..", "content");
        string? executionPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);

        if (!string.IsNullOrEmpty(executionPath))
        {
            string? localEmbeddingsModel = Path.Combine(executionPath, "LocalEmbeddingsModel");
            if (!Directory.Exists(localEmbeddingsModel))
            {
                _ = Directory.CreateDirectory(localEmbeddingsModel);
            }
            string? outputPath = Path.Combine(localEmbeddingsModel, "default");
            if (!Directory.Exists(outputPath))
            {
                _ = Directory.CreateDirectory(outputPath);
            }
            foreach (string onnx in Directory.GetFiles(embeddingsPath, "*.onnx"))
            {
                File.Copy(onnx, Path.Combine(outputPath, "model.onnx"), true);
                break;
            }

            foreach (string onnx in Directory.GetFiles(embeddingsPath, "*vocab.txt"))
            {
                File.Copy(onnx, Path.Combine(outputPath, "vocab.txt"), true);
                break;
            }
        }


        return services
            .AddSingleton<LocalEmbedder>()
            .AddSingleton<IEmbeddingGenerator, LocalEmbeddingGenerator>()
            .AddSingleton<IRagStore, FileSystemRagStore>()
            .AddSingleton<IRagIndexer, RagIndexer>()
            .AddSingleton<IRagStoreReader, FileSystemRagStoreReader>()
            .AddTransient<ISemanticSearchService, SemanticSearchService>()
            .AddSingleton<RagMCPTools>()
            .AddSingleton<ITokenizer, BertTokenizer>()
            .AddTransient<ITokenChunker, TokenChunker>();
        //.AddSingleton<ISemanticSearchService, SemanticSearchService>();
    }
}
