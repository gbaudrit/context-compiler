using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Files
{
    public interface ILinearFileReader : IDisposable
    {
        Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
    }
}
