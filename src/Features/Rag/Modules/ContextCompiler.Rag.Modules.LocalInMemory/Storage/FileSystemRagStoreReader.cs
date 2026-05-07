using System.Text.Json;

using ContextCompiler.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Storage;

public sealed class FileSystemRagStoreReader : IRagStoreReader
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = false
    };


    private readonly string _rootPath;
    private readonly string _chunksPath;
    private readonly string _embeddingsPath;
    private readonly string _embeddingIndexPath;


    public FileSystemRagStoreReader(ICompiledWorkingFolder compiledWorkingFolder)
    {
        _rootPath = compiledWorkingFolder.Combine("rag");
        _chunksPath = Path.Combine(_rootPath, "chunks.jsonl");
        _embeddingsPath = Path.Combine(_rootPath, "embeddings.bin");
        _embeddingIndexPath = Path.Combine(_rootPath, "embeddings.index.jsonl");
    }

    public async ValueTask<RagManifest?> ReadManifestAsync(
        CancellationToken cancellationToken = default)
    {
        string path = Path.Combine(_rootPath, "manifest.json");
        if (!File.Exists(path))
        {
            return null;
        }

        string json = await File.ReadAllTextAsync(path, cancellationToken);
        return JsonSerializer.Deserialize<RagManifest>(json, JsonOptions);
    }

    public async ValueTask<IReadOnlyList<TextChunk>> ReadChunksAsync(
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_chunksPath))
        {
            return [];
        }

        List<TextChunk> chunks = [];

        foreach (string line in await File.ReadAllLinesAsync(_chunksPath, cancellationToken))
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
        if (!File.Exists(_embeddingIndexPath) || !File.Exists(_embeddingsPath))
        {
            return [];
        }

        List<EmbeddingRecord> embeddings = [];

        using FileStream stream = new(_embeddingsPath, FileMode.Open, FileAccess.Read, FileShare.Read);

        foreach (string line in await File.ReadAllLinesAsync(_embeddingIndexPath, cancellationToken))
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
