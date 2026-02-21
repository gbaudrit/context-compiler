using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Modules.Abstractions;

public interface IFileReaderModule : IModule
{
    bool CanRead(string path);
    //Task<IFileReadResult> ReadAsync(string path, CancellationToken ct);
    Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
}
