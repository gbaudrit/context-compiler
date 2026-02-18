using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Plugins.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class TextFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ILinearFileReader linearFileReader, ILogger<TextFileReaderPlugin> logger) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.text.reader", GlobalPipelinePluginKinds.FileReader, priority: 0);

    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".csproj",".props"
    };

    public bool CanRead(string path)
    {
        return Extensions.Contains(Path.GetExtension(path));
    }

    //public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    //{
    //    logger.LogInformation("Reading text file: {Path}", path);
    //    ct.ThrowIfCancellationRequested();
    //    var bytes = File.ReadAllBytes(path);
    //    var text = Encoding.UTF8.GetString(bytes);
    //    return Task.FromResult(fileReadResultBuilder.InitNew()
    //                                                .WithContent(fileContentBuilder.InitNew()
    //                                                                               .WithPath(path)
    //                                                                               .WithMediaType("text/plain")
    //                                                                               .WithReaderType<TextFileReader>()
    //                                                                               .Build()).Build());
    //}

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}

//public sealed class TextFileReader(ILinearFileReader linearFileReader) : IFileReader
//{
//    private bool disposedValue;

//    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        return ValueTask.FromResult<IFileContent>(new TextFileContent
//        {
//            Stream = File.OpenRead(path)
//        });
//    }


//    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
//    {
//        return await linearFileReader.ReadAsync(documentContext, ct);
//    }

//    private void Dispose(bool disposing)
//    {
//        if (!disposedValue)
//        {
//            if (disposing)
//            {
//                linearFileReader.Dispose();
//            }

//            linearFileReader = null!;
//            disposedValue = true;
//        }
//    }

//    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
//    // ~TextFileReader()
//    // {
//    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//    //     Dispose(disposing: false);
//    // }

//    public void Dispose()
//    {
//        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//        Dispose(disposing: true);
//        GC.SuppressFinalize(this);
//    }
//}

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
