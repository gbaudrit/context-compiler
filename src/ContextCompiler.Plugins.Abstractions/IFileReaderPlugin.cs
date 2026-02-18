using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Plugins.Abstractions;

public interface IFileReaderPlugin : IPlugin
{
    bool CanRead(string path);
    //Task<IFileReadResult> ReadAsync(string path, CancellationToken ct);
    Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
}
