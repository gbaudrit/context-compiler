using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Files
{
    public interface ILinearFileReader : IDisposable
    {
        Task<IDocumentContextPatch> ReadAsync(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct);
    }
}
