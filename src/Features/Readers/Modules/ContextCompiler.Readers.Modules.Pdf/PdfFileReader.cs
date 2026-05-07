using System.Text;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Readers.Modules.Pdf.Configurations;

using Microsoft.Extensions.Logging;

using Tabula;
using Tabula.Detectors;
using Tabula.Extractors;
using Tabula.Writers;

using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace ContextCompiler.Readers.Modules.Pdf;

public sealed class PdfFileReaderModule(IFileReadResultBuilder fileReadResultBuilder,
                                        IFileContentBuilder fileContentBuilder,
                                        IConfigProvider cfgProvider,
                                        IDataPartBuilder dataPartBuilder,
                                        ITagsBuilder tagsBuilder,
                                        ISourceRefBuilder sourceRefBuilder,
                                        ILogger<PdfFileReaderModule> logger) : IFileReaderModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("readers.pdf", InputIngestionPipelineModuleKinds.ReadDocument, priority: 10);

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        string ext = Path.GetExtension(InputItemContext.FullPath);
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

    public Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        logger.LogInformation("Start reading PDF InputItem at path: {Path}", context.InputItem.FullPath);


        IRootConfigSection cfg = cfgProvider.GetConfigOrDefault(null);

        //var fileExtracts = new List<(string match, PdfDefaults? defaults, List<PdfExtractConfig> extracts)>();
        //foreach (var f in cfg.Files)
        //{
        //    if (f.Excel is null) continue;
        //    foreach (var s in f.Includes)
        //    {
        //        fileExtracts.Add((s, f.Excel.Defaults, f.Excel.Extracts));
        //    }

        //}
        PdfExtractsConfig options = context.InputItem.Source.Config<PdfExtractsConfig>() ?? new PdfExtractsConfig();

        using PdfDocument pdfDocument = PdfDocument.Open(context.InputItem.FullPath!, new ParsingOptions() { ClipPaths = true });
        string sourcePath = context.InputItem.FullPath ?? string.Empty;

        List<IDataPart> parts = [];
        foreach (PdfExtractConfig extract in options.Extracts)
        {
            foreach (Page? page in pdfDocument.GetPages().Where(p => p.Number >= extract.StartPage && p.Number <= extract.EndPage && !extract.PageExcludes.Contains(p.Number)))
            {
                object payload = "";
                if (extract.IsArray.Contains(page.Number))
                {
                    PageArea pageArea = ObjectExtractor.Extract(pdfDocument, page.Number);
                    SimpleNurminenDetectionAlgorithm detector = new();
                    IReadOnlyList<TableRectangle> regions = detector.Detect(pageArea);

                    IReadOnlyList<Table> tables;

                    //BasicExtractionAlgorithm ea1 = new();
                    //tables = ea1.Extract(pageArea.GetArea(regions[0].BoundingBox)); // take first candidate area

                    SpreadsheetExtractionAlgorithm ea2 = new();
                    tables = ea2.Extract(pageArea);

                    Table table = tables[0];
                    IReadOnlyList<IReadOnlyList<Cell>> rows = table.Rows;
                    JSONWriter serializer = new();
                    StringBuilder sb = new();
                    serializer.Write(sb, table);
                    payload = sb.ToString();
                }
                else
                {
                    payload = ContentOrderTextExtractor.GetText(page, new ContentOrderTextExtractor.Options() { NegativeGapAsWhitespace = true, SeparateParagraphsWithDoubleNewline = true });
                }
                string locatorPrefix = $"page:{page.Number}";
                parts.Add(dataPartBuilder.InitNew()
                                             .WithId(extract.Id)
                                             .WithSource(sourceRefBuilder.InitNew().WithPath(sourcePath).WithLocator(locatorPrefix).Build())
                                             .WithLabel("Page " + page.Number)
                                             .WithPayload(payload)
                                             .WithTags(tagsBuilder.InitNew().AddRange(extract.Tags).Build())
                                             .Build());
            }
        }


        logger.LogInformation("Finished reading PDF InputItem at path: {Path}. Extracted {PartCount} parts.", context.InputItem.FullPath, parts.Count);

        return context.Patch(b =>
        {
            _ = b.WithDataEnvelope(x => x.WithDataShape(DataShape.Linear).WithParts(parts));
        }).Success();

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
//            InputItem = PdfDocument.Open(path)
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
