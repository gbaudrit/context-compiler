using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

public interface IRagIndexer
{
    ValueTask IndexAsync(
        TextChunk chunk,
        CancellationToken cancellationToken = default);
}
