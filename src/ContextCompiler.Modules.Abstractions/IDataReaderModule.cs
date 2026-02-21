using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Modules.Abstractions;

public interface IDataReaderModule : IModule
{
    bool CanRead(IFileInfos doc);
    Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct);
}
