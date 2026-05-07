using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

public interface IRagIndexer
{
    ValueTask IndexAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default);
}
