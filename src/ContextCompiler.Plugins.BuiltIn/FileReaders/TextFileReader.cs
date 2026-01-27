using System.Text;

using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class TextFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ILogger<TextFileReaderPlugin> logger) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.text.reader", GlobalPipelinePluginKinds.FileReader, priority: 0);

    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".csproj",".props"
    };

    public bool CanRead(string path) => Extensions.Contains(Path.GetExtension(path));

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        logger.LogInformation("Reading text file: {Path}", path);
        ct.ThrowIfCancellationRequested();
        var bytes = File.ReadAllBytes(path);
        var text = Encoding.UTF8.GetString(bytes);
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("text/plain")
                                                                                   .WithReaderType<TextFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class TextFileReader : IFileReader
{

    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<IFileContent>(new TextFileContent
        {
            Stream = File.OpenRead(path)
        });
    }
}

public sealed class TextFileContent : IFileContent
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
