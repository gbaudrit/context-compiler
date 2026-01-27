using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.FileReaders;

public sealed class ExcelFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder)  : IFileReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.excel.reader", GlobalPipelinePluginKinds.FileReader, priority: 10);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || ext.Equals(".xlsm", StringComparison.OrdinalIgnoreCase);
    }

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                                                                                   .WithReaderType<ExcelFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class ExcelFileReader : IFileReader
{

    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<IFileContent>(new ExcelFileContent
        {
            Stream = File.OpenRead(path)
        });
    }
}

public sealed class ExcelFileContent : IFileContent
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

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~ExcelFileContent()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
