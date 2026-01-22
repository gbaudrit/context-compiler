using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
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
        var stream = File.OpenRead(path);
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

    public ValueTask<Stream> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<Stream>(File.OpenRead(path));
    }
}
