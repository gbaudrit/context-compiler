using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class YamlFileReader : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.yaml.reader", PluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".yaml", StringComparison.OrdinalIgnoreCase) || ext.Equals(".yml", StringComparison.OrdinalIgnoreCase);
    }

    public Task<DocumentContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var text = File.ReadAllText(path);
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        return Task.FromResult(new DocumentContent(path, "text/yaml", bytes, text));
    }
}
