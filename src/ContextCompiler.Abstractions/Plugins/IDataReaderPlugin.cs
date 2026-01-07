using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Plugins;

public interface IDataReaderPlugin : IPlugin
{
    bool CanRead(DocumentContent doc);
    Task<IDataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct);
}
