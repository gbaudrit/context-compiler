using System.Text.Json;

using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Models;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Storage;

public sealed class RagStoreReader : IRagStoreReader
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = false
    };


    private readonly IStore _rootPath;
    private readonly IStoreResource _chunksPath;
    private readonly IStoreResource _embeddingsPath;
    private readonly IStoreResource _embeddingIndexPath;


    public RagStoreReader([FromKeyedServices(StoreKeys.Cache)] IStore cacheStore)
    {
        _rootPath = cacheStore.GetContainer("rag");
        _chunksPath = _rootPath.GetResource("chunks.jsonl");
        _embeddingsPath = _rootPath.GetResource("embeddings.bin");
        _embeddingIndexPath = _rootPath.GetResource("embeddings.index.jsonl");
    }

    public async ValueTask<RagManifest?> ReadManifestAsync(
        CancellationToken cancellationToken = default)
    {
        IStoreResource manifestPath = _rootPath.GetResource("manifest.json");
        if (!await manifestPath.Exists())
        {
            return null;
        }

        string json = await manifestPath.ReadAllText(cancellationToken);
        return JsonSerializer.Deserialize<RagManifest>(json, JsonOptions);
    }

    public async ValueTask<IReadOnlyList<TextChunk>> ReadChunksAsync(
        CancellationToken cancellationToken = default)
    {
        if (!await _chunksPath.Exists())
        {
            return [];
        }

        List<TextChunk> chunks = [];

        foreach (string line in await _chunksPath.ReadAllLines(cancellationToken))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            TextChunk? chunk = JsonSerializer.Deserialize<TextChunk>(line, JsonOptions);
            if (chunk is not null)
            {
                chunks.Add(chunk);
            }
        }

        return chunks;
    }

    public async ValueTask<IReadOnlyList<EmbeddingRecord>> ReadEmbeddingsAsync(
        CancellationToken cancellationToken = default)
    {
        if (!await _embeddingIndexPath.Exists() || !await _embeddingsPath.Exists())
        {
            return [];
        }

        List<EmbeddingRecord> embeddings = [];

        using Stream stream = _embeddingsPath.CreateStreamForRead();

        foreach (string line in await _embeddingIndexPath.ReadAllLines(cancellationToken))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            EmbeddingIndexEntry? entry = JsonSerializer.Deserialize<EmbeddingIndexEntry>(line, JsonOptions);
            if (entry is null)
            {
                continue;
            }

            byte[] buffer = new byte[entry.Length];
            stream.Position = entry.Offset;
            _ = await stream.ReadAsync(buffer, cancellationToken);

            embeddings.Add(new EmbeddingRecord(
                ChunkId: entry.ChunkId,
                Buffer: buffer,
                EmbeddingType: entry.EmbeddingType));
        }

        return embeddings;
    }
}
