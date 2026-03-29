using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

public interface ISemanticSearchService
{
    ValueTask<IReadOnlyList<SearchHit>> SearchAsync(
        string query,
        int maxResults = 5,
        float? minSimilarity = null,
        CancellationToken cancellationToken = default);
}
