using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface IFileReaderPlugin : IPlugin
{
    bool CanRead(string path);
    Task<DocumentContent> ReadAsync(string path, CancellationToken ct);
}
