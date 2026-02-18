using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Plugins.Abstractions;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class MarkdownFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ILinearFileReader linearFileReader) : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.markdown.reader", GlobalPipelinePluginKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        string ext = Path.GetExtension(path);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    //public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    //{
    //    ct.ThrowIfCancellationRequested();
    //    var stream = File.OpenRead(path);
    //    return Task.FromResult(fileReadResultBuilder.InitNew()
    //                                                .WithContent(fileContentBuilder.InitNew()
    //                                                                               .WithPath(path)
    //                                                                               .WithMediaType("text/markdown")
    //                                                                               .WithReaderType<MarkdownFileReader>()
    //                                                                               .Build()).Build());
    //}

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}

//public sealed class MarkdownFileReader(ILinearFileReader linearFileReader) : IFileReader
//{
//    private bool disposedValue;

//    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        return ValueTask.FromResult<IFileContent>(new MarkdownFileContent
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
//    // ~MarkdownFileReader()
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
