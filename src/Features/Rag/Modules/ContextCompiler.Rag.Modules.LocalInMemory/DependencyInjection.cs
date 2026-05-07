using System.Reflection;

using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Embeddings;
using ContextCompiler.Rag.Modules.LocalInMemory.Indexation;
using ContextCompiler.Rag.Modules.LocalInMemory.MCP;
using ContextCompiler.Rag.Modules.LocalInMemory.Search;
using ContextCompiler.Rag.Modules.LocalInMemory.Storage;
using ContextCompiler.Rag.Modules.LocalInMemory.Tokenizers;

using Microsoft.Extensions.DependencyInjection;

using SmartComponents.LocalEmbeddings;

namespace ContextCompiler.Rag.Modules.LocalInMemory;

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
            //.AddSingleton<ITokenizer, BertTokenizer>()
            .AddSingleton<ITokenizer, MLTokenizer>()
            .AddTransient<ITokenChunker, TokenChunker>();
        //.AddSingleton<ISemanticSearchService, SemanticSearchService>();
    }
}
