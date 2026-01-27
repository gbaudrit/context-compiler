using System.Security.Cryptography;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Plugins.Readers.Pdf;

using UglyToad.PdfPig;

namespace ContextCompiler.Plugins.Readers.PDF;

public sealed class PdfFileReaderPlugin(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder)  : IFileReaderPlugin
{
    public PluginMetadata Metadata => IPlugin.Meta("readers.pdf", GlobalPipelinePluginKinds.FileReader, priority: 10);

    public bool CanRead(string path)
    {
        var ext = Path.GetExtension(path);
        return ext.Equals(".pdf", StringComparison.OrdinalIgnoreCase);
    }

    //public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    //{
    //    ct.ThrowIfCancellationRequested();
    //    var stream = File.OpenRead(path);
    //    return Task.FromResult(fileReadResultBuilder.InitNew()
    //                                                .WithContent(fileContentBuilder.InitNew()
    //                                                                               .WithPath(path)
    //                                                                               .WithMediaType("application/pdf")
    //                                                                               .WithReaderType<PdfFileReader>()
    //                                                                               .Build()).Build());
    //}

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var cfg = cfgProvider.GetConfigOrDefault(null);

        //var fileExtracts = new List<(string match, PdfDefaults? defaults, List<PdfExtractConfig> extracts)>();
        //foreach (var f in cfg.Files)
        //{
        //    if (f.Excel is null) continue;
        //    foreach (var s in f.Includes)
        //    {
        //        fileExtracts.Add((s, f.Excel.Defaults, f.Excel.Extracts));
        //    }

        //}
        using PdfDocument pdfDocument = PdfDocument.Open(documentContext.FullPath!);
        var sourcePath = documentContext.FullPath ?? string.Empty;

        var parts = new List<IDataPart>();
        foreach (var page in pdfDocument.GetPages())
        {
            var locatorPrefix = $"page:{page.Number}";
            parts.Add(dataPartBuilder.InitNew()
                                         .WithId(locatorPrefix)
                                         .WithSource(new SourceRef(sourcePath, locatorPrefix))
                                         .WithLabel("Page " + page.Number)
                                         .WithPayload(page.Text)
                                         .WithTags(tagsBuilder.InitNew().Build()) //.AddRange(x.Tags)
                                         .Build());
        }

        return dataEnvelopeBuilder.InitNew()
                                    .WithDataShape(DataShape.Linear)
                                    .WithParts(parts)
                                    .Build();

    }
}

//public sealed class PdfFileReader(ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder) : IFileReader
//{
//    private PdfFileContent? _pdfFileContent;
//    private bool disposedValue;

//    public ValueTask<IFileContent> ReadAsync(string path, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        _pdfFileContent = new PdfFileContent
//        {
//            Document = PdfDocument.Open(path)
//        };
//        return ValueTask.FromResult<IFileContent>(_pdfFileContent);
//    }

    

//    private void Dispose(bool disposing)
//    {
//        if (!disposedValue)
//        {
//            if (disposing)
//            {
//                _pdfFileContent?.Dispose();
//            }

//            _pdfFileContent = null;
//            disposedValue = true;
//        }
//    }

//    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
//    // ~PdfFileReader()
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
