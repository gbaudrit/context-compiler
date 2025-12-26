using ClosedXML.Excel;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.DataReaders;

public sealed class ExcelTabularDataReader : IDataReaderPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.data.excel.tabular", PluginKinds.DataReader, priority: 10);

    public bool CanRead(DocumentContent doc) => doc.MediaType.Contains("spreadsheet", StringComparison.OrdinalIgnoreCase);

    public Task<DataEnvelope> ReadAsync(DocumentContent doc, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        using var ms = new MemoryStream(doc.Bytes);
        using var wb = new XLWorkbook(ms);

        var sheets = new List<object>();
        foreach (var ws in wb.Worksheets)
        {
            var used = ws.RangeUsed();
            if (used is null) continue;

            var rows = new List<List<string>>();
            foreach (var row in used.Rows())
            {
                var r = new List<string>();
                foreach (var cell in row.Cells())
                    r.Add(cell.GetFormattedString());
                rows.Add(r);
            }

            sheets.Add(new { name = ws.Name, rows });
        }

        return Task.FromResult(new DataEnvelope(DataShape.Tabular, new { sheets }, new Dictionary<string,string>{{"mediaType",doc.MediaType}}));
    }
}
