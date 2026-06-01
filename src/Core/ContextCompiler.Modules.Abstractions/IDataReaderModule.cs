using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Modules.Abstractions;

public interface IDataReaderModule : IModule
{
    bool CanRead(IFileInfos doc);
    Task<IDataEnvelope> ReadAsync(IInputItemContext InputItemContext, CancellationToken ct);
}
