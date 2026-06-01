namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

public interface ITokenChunker
{
    Task<IReadOnlyList<string>> SplitChunksByToken(string text, int maxTokens = 512, int overlapTokens = 64, CancellationToken cancellationToken = default);

}
