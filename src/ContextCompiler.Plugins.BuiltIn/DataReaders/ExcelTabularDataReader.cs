//using ClosedXML.Excel;

//using ContextCompiler.Abstractions.Files;
//using ContextCompiler.Abstractions.Models;
//using ContextCompiler.Abstractions.Pipelines.Document;
//using ContextCompiler.Abstractions.Plugins;

//namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

//public sealed class ExcelTabularDataReader(IDataEnvelopeBuilder dataEnvelopeBuilder) : IDataReaderPlugin
//{
//    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.excel.tabular", PluginKinds.DataReader, priority: 10);

//    public bool CanRead(IFileInfos doc) => doc.MediaType.Contains("spreadsheet", StringComparison.OrdinalIgnoreCase);

//    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
//    {
//        ct.ThrowIfCancellationRequested();

//        using var ms = await documentContext.GetContentStream();
//        ms.Position = 0;
//        using var wb = new XLWorkbook(ms);

//        var sheets = new List<object>();
//        foreach (var ws in wb.Worksheets)
//        {
//            var used = ws.RangeUsed();
//            if (used is null) continue;

//            var rows = new List<List<string>>();
//            foreach (var row in used.Rows())
//            {
//                var r = new List<string>();
//                foreach (var cell in row.Cells())
//                    r.Add(cell.GetFormattedString());
//                rows.Add(r);
//            }

//            sheets.Add(new { name = ws.Name, rows });
//        }

//        return dataEnvelopeBuilder.InitNew().WithDataShape(DataShape.Tabular).WithPayload(new { sheets }).WithMetadata(new Dictionary<string,string>{{"mediaType", documentContext.FileInfos.MediaType}}).Build();
//    }
//}
