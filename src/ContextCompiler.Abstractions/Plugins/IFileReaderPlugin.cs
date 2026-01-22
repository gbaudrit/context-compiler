using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Plugins;

public interface IFileReaderPlugin : IPlugin
{
    bool CanRead(string path);
    Task<IFileReadResult> ReadAsync(string path, CancellationToken ct);
}
