using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class MarkdownFileReader : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.markdown.reader", PluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public Task<DocumentContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var text = File.ReadAllText(path);
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        return Task.FromResult(new DocumentContent(path, "text/markdown", bytes, text));
    }
}
