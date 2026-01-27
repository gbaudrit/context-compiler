using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class MarkdownFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.markdown.reader", GlobalPipelinePluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var stream = File.OpenRead(path);
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("text/markdown")
                                                                                   .WithReaderType<MarkdownFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class MarkdownFileReader : IFileReader
{

    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<IFileContent>(new MarkdownFileContent
        {
            Stream = File.OpenRead(path)
        });
    }
}

public sealed class MarkdownFileContent : IFileContent
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
