using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface IDataReaderPlugin : IPlugin
{
    bool CanRead(DocumentContent doc);
    Task<DataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct);
}
