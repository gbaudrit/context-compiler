using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

public interface ISemanticSearchService
{
    ValueTask<IReadOnlyList<SearchHit>> SearchAsync(
        string query,
        int maxResults = 5,
        float? minSimilarity = null,
        CancellationToken cancellationToken = default);
}
