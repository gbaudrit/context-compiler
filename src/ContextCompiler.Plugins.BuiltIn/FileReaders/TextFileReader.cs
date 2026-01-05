using System.Text;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class TextFileReader : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.text.reader", PluginKinds.FileReader, priority: 0);

    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".csproj",".props"
    };

    public bool CanRead(string path) => Extensions.Contains(Path.GetExtension(path));

    public Task<DocumentContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var bytes = File.ReadAllBytes(path);
        var text = Encoding.UTF8.GetString(bytes);
        return Task.FromResult(new DocumentContent(path, "text/plain", bytes, text));
    }
}
