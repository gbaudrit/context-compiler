using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Plugins.Readers.Pdf;

using UglyToad.PdfPig;

namespace ContextCompiler.Plugins.Readers.PDF;

public sealed class PdfFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder)  : IFileReaderPlugin
{
    public PluginMetadata Metadata => IPlugin.Meta("readers.pdf", GlobalPipelinePluginKinds.FileReader, priority: 10);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".pdf", StringComparison.OrdinalIgnoreCase);
    }

    public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var stream = File.OpenRead(path);
        return Task.FromResult(fileReadResultBuilder.InitNew()
                                                    .WithContent(fileContentBuilder.InitNew()
                                                                                   .WithPath(path)
                                                                                   .WithMediaType("application/pdf")
                                                                                   .WithReaderType<PdfFileReader>()
                                                                                   .Build()).Build());
    }
}

public sealed class PdfFileReader : IFileReader
{

    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return ValueTask.FromResult<IFileContent>(new PdfFileContent
        {
            Document = PdfDocument.Open(path)
        });
    }
}
