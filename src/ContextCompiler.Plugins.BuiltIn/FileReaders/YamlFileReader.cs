using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class YamlFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.yaml.reader", GlobalPipelinePluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".yaml", StringComparison.OrdinalIgnoreCase) || ext.Equals(".yml", StringComparison.OrdinalIgnoreCase);
    }

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("text/yaml")
                                                                                   .WithReaderType<YamlFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class YamlFileReader : IFileReader
{

    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<IFileContent>(new YamlFileContent
        {
            Stream = File.OpenRead(path)
        });
    }
}

public sealed class YamlFileContent : IFileContent
{
    private bool disposedValue;
    public required FileStream Stream { get; init; }
    private bool _readen;
    public Stream NextPart()
    {
        if (_readen)
        {
            return System.IO.Stream.Null;
        }
        _readen = true;
        return Stream;
    }
    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Stream.Dispose();
            }
            disposedValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
