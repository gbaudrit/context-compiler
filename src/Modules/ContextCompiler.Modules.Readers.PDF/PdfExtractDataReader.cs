//using ContextCompiler.Abstractions.Configuration;
//using ContextCompiler.Abstractions.Files;
//using ContextCompiler.Abstractions.Models;
//using ContextCompiler.Abstractions.Pipelines.Document;
//using ContextCompiler.Abstractions.Plugins;
//using ContextCompiler.Abstractions.Tags;
//using ContextCompiler.Modules.Readers.Pdf.Configurations;

//namespace ContextCompiler.Modules.Readers.Pdf;

//public sealed class PdfExtractDataReader(ICtxcConfigProvider cfgProvider, IDataEnvelopeBuilder dataEnvelopeBuilder, IDataPartBuilder dataPartBuilder, ITagsBuilder tagsBuilder) : IDataReaderPlugin
//{
//    public PluginMetadata Metadata => IPlugin.Meta("builtin.data.pdf.extract", GlobalPipelinePluginKinds.DataReader, priority: 9);

//    public bool CanRead(IFileInfos doc) => doc.MediaType.Contains("application/pdf", StringComparison.OrdinalIgnoreCase);

//    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();
//        var cfg = cfgProvider.GetConfigOrDefault(null);

//        //var fileExtracts = new List<(string match, PdfDefaults? defaults, List<PdfExtractConfig> extracts)>();
//        //foreach (var f in cfg.Files)
//        //{
//        //    if (f.Excel is null) continue;
//        //    foreach (var s in f.Includes)
//        //    {
//        //        fileExtracts.Add((s, f.Excel.Defaults, f.Excel.Extracts));
//        //    }

//        //}

//        using var ms2 = await documentContext.GetContentStream();
//        Stream s = ms2.NextPart();

//        var parts = new List<IDataPart>();
//        var sourcePath = documentContext.FullPath ?? string.Empty;
//        var index = 0;
//        var locatorPrefix = "";

//        while (s != Stream.Null)
//        {
//            locatorPrefix = $"page:{index}";
//            using StreamReader sr = new StreamReader(s);
//            parts.Add(dataPartBuilder.InitNew()
//                                          .WithId(locatorPrefix)
//                                          .WithSource(new SourceRef(sourcePath, locatorPrefix))
//                                          .WithLabel("Page " + index)
//                                          .WithPayload(sr.ReadToEnd())
//                                          .WithTags(tagsBuilder.InitNew().Build()) //.AddRange(x.Tags)
//                                          .Build());
//            index++;
//            s = ms2.NextPart();
//        }

//        return dataEnvelopeBuilder.InitNew()
//                                    .WithDataShape(DataShape.Tabular)
//                                    .WithParts(parts)
//                                    .Build();

//    }

//}
