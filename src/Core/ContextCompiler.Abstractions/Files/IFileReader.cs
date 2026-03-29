using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReader : IDisposable
    {
        ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct);

        Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
    }
}
