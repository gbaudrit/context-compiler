using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Models;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Storage;

public sealed class RagStore : IRagStore, IAsyncDisposable
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = false
    };

    private readonly IStore _rootPath;
    private readonly IStoreResource _chunksPath;
    private readonly IStoreResource _embeddingsPath;
    private readonly IStoreResource _embeddingIndexPath;
    private readonly IOutput _output;

    private readonly SemaphoreSlim _gate = new(1, 1);

    private Stream? _embeddingsStream;
    private StreamWriter? _chunksWriter;
    private StreamWriter? _embeddingIndexWriter;

    private bool _initialized;
    private bool _completed;
    private bool _disposed;

    public RagStore([FromKeyedServices(StoreKeys.Cache)] IStore cacheStore, IOutput output)
    {
        _rootPath = cacheStore.CreateContainer("rag");
        _chunksPath = _rootPath.GetResource("chunks.jsonl");
        _embeddingsPath = _rootPath.GetResource("embeddings.bin");
        _embeddingIndexPath = _rootPath.GetResource("embeddings.index.jsonl");

        _output = output;
    }

    private async ValueTask EnsureInitialized(CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (_initialized)
            {
                return;
            }

            _chunksWriter = _chunksPath.CreateWriter();

            _embeddingIndexWriter = _embeddingIndexPath.CreateWriter();
            _embeddingsStream = _embeddingsPath.CreateStream();

            _initialized = true;
        }
        finally
        {
            _ = _gate.Release();
        }
    }

    public async ValueTask AppendAsync(
        TextChunk chunk,
        EmbeddingRecord embedding,
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        await EnsureInitialized(cancellationToken);

        await _gate.WaitAsync(cancellationToken);
        try
        {
            EnsureNotCompleted();

            if (_chunksWriter is null || _embeddingIndexWriter is null || _embeddingsStream is null)
            {
                throw new InvalidOperationException("Le store RAG n'est pas correctement initialisé.");
            }

            long offset = _embeddingsStream.Position;
            await _embeddingsStream.WriteAsync(embedding.Buffer, cancellationToken);
            await _embeddingsStream.FlushAsync(cancellationToken);

            EmbeddingIndexEntry indexEntry = new(
                ChunkId: chunk.Id,
                Offset: offset,
                Length: embedding.Buffer.Length,
                EmbeddingType: embedding.EmbeddingType);

            string chunkJson = JsonSerializer.Serialize(chunk, JsonOptions);
            await _chunksWriter.WriteLineAsync(chunkJson);
            await _chunksWriter.FlushAsync(cancellationToken);

            string indexJson = JsonSerializer.Serialize(indexEntry, JsonOptions);
            await _embeddingIndexWriter.WriteLineAsync(indexJson);
            await _embeddingIndexWriter.FlushAsync(cancellationToken);
        }
        finally
        {
            _ = _gate.Release();
        }
    }

    public async ValueTask Flush(
        CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        await _gate.WaitAsync(cancellationToken);
        try
        {
            await EnsureInitialized(cancellationToken);

            if (_completed)
            {
                return;
            }

            if (_chunksWriter is not null)
            {
                _output.AddArtifact(builder =>
                {
                    return builder.WithStoreResource(_chunksPath)
                                  .IsStreamedContent()
                                  .WithDescription("Chunks index file")
                                  .WithGeneratedBy(GetType());
                });

                await _chunksWriter.FlushAsync(cancellationToken);
                await _chunksWriter.DisposeAsync();
                _chunksWriter = null;
            }

            if (_embeddingIndexWriter is not null)
            {
                _output.AddArtifact(builder =>
                {
                    return builder.WithStoreResource(_embeddingIndexPath)
                                  .IsStreamedContent()
                                  .WithDescription("Embeddings index file")
                                  .WithGeneratedBy(GetType());
                });

                await _embeddingIndexWriter.FlushAsync(cancellationToken);
                await _embeddingIndexWriter.DisposeAsync();
                _embeddingIndexWriter = null;
            }

            if (_embeddingsStream is not null)
            {
                _output.AddArtifact(builder =>
                {
                    return builder.WithStoreResource(_embeddingsPath)
                                  .IsStreamedContent()
                                  .WithDescription("Embeddings store")
                                  .WithGeneratedBy(GetType());
                });

                await _embeddingsStream.FlushAsync(cancellationToken);
                await _embeddingsStream.DisposeAsync();
                _embeddingsStream = null;
            }

            _completed = true;
        }
        finally
        {
            _ = _gate.Release();
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        await _gate.WaitAsync();
        try
        {
            if (_chunksWriter is not null)
            {
                await _chunksWriter.DisposeAsync();
                _chunksWriter = null;
            }

            if (_embeddingIndexWriter is not null)
            {
                await _embeddingIndexWriter.DisposeAsync();
                _embeddingIndexWriter = null;
            }

            if (_embeddingsStream is not null)
            {
                await _embeddingsStream.DisposeAsync();
                _embeddingsStream = null;
            }

            _disposed = true;
        }
        finally
        {
            _ = _gate.Release();
            _gate.Dispose();
        }
    }

    private void EnsureNotCompleted()
    {
        if (_completed)
        {
            throw new InvalidOperationException("Le store RAG est déjà finalisé.");
        }
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, nameof(RagStore));
    }
}
