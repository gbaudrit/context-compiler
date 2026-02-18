using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Plugins.Abstractions;

public interface IDataReaderPlugin : IPlugin
{
    bool CanRead(IFileInfos doc);
    Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
}
