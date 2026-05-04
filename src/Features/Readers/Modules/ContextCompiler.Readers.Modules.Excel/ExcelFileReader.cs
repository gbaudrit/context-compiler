using ClosedXML.Excel;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.Tags;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Readers.Modules.Excel.Configurations;

namespace ContextCompiler.Readers.Modules.Excel;

public sealed class ExcelFileReaderModule(
    IFileReadResultBuilder fileReadResultBuilder,
    IFileContentBuilder fileContentBuilder,
    IConfigProvider cfgProvider,
    IDataEnvelopeBuilder dataEnvelopeBuilder,
    IDataPartBuilder dataPartBuilder,
    ITagsBuilder tagsBuilder,
    ISourceRefBuilder sourceRefBuilder) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("readers.excel", DocumentPipelineModuleKinds.ReadDocument, priority: 10);

    public bool CanProcess(IDocumentContext documentContext)
    {
        string ext = Path.GetExtension(documentContext.FullPath);
        return ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || ext.Equals(".xlsm", StringComparison.OrdinalIgnoreCase);
    }

    //public Task<IFileReadResult> ReadAsync(string path, CancellationToken ct)
    //{
    //    ct.ThrowIfCancellationRequested();
    //    return Task.FromResult(fileReadResultBuilder.InitNew()
    //                                                .WithContent(fileContentBuilder.InitNew()
    //                                                                               .WithPath(path)
    //                                                                               .WithMediaType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
    //                                                                               .WithReaderType<ExcelFileReader>()
    //                                                                               .Build()).Build());
    //}

    public Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        IRootConfigSection cfg = cfgProvider.GetConfigOrDefault(null);
        ExcelFileSection options = context.Document.Source.Config<ExcelFileSection>() ?? new ExcelFileSection();

        //var fileExtracts = new List<(string match, ExcelDefaults? defaults, List<ExcelExtractConfig> extracts)>();
        //foreach (var f in cfg.Files)
        //{
        //    foreach (var s in f.Includes)
        //    {
        //        fileExtracts.Add((s, options.Defaults, options.Extracts));
        //    }

        //}

        using FileStream ms2 = File.OpenRead(context.Document.FullPath ?? string.Empty);
        using XLWorkbook wb2 = new(ms2);
        List<IDataPart> parts = [];
        string sourcePath = context.Document.FullPath ?? string.Empty;

        foreach (ExcelExtractConfig? x in options.Extracts.OrderBy(e => e.Id, StringComparer.Ordinal))
        {
            IXLWorksheet? sheet = wb2.Worksheets.FirstOrDefault(ws => string.Equals(ws.Name, x.Sheet, StringComparison.Ordinal));
            if (sheet is null)
            {
                continue;
            }

            sheet = sheet.ExpandRows();
            sheet = sheet.ExpandColumns();

            IXLRange range = sheet.RangeUsed()!;
            if (!string.IsNullOrEmpty(x.Range))
            {
                range = sheet.Range(x.Range);
            }

            List<List<string>> rows = [];
            foreach (IXLRangeRow? row in range.Rows())
            {
                List<string> r = [];
                foreach (IXLCell? cell in row.Cells())
                {
                    r.Add(cell.GetFormattedString());
                }

                rows.Add(r);
            }

            int toSkip = x.Skip.GetValueOrDefault(0);
            if (toSkip > 0 && toSkip < rows.Count)
            {
                rows = [.. rows.Skip(toSkip)];
            }

            int[]? headerRowIndices = x.HeaderRowIndex;
            if (headerRowIndices is null || headerRowIndices.Length == 0)
            {
                headerRowIndices = [0];
            }

            // Normaliser les indices négatifs
            for (int i = 0; i < headerRowIndices.Length; i++)
            {
                if (headerRowIndices[i] < 0)
                {
                    headerRowIndices[i] = 0;
                }
            }

            if (rows.Count == 0)
            {
                continue;
            }

            // Construire l'en-tête en combinant les lignes d'en-tête multiples
            List<string> headerParts = [];
            int maxHeaderIndex = headerRowIndices.Max();

            if (maxHeaderIndex >= rows.Count)
            {
                maxHeaderIndex = rows.Count - 1;
            }

            // Pour chaque colonne, combiner les valeurs des lignes d'en-tête
            int columnCount = rows[Math.Min(headerRowIndices[0], rows.Count - 1)].Count;
            for (int col = 0; col < columnCount; col++)
            {
                List<string> headerValues = [];
                foreach (int headerIdx in headerRowIndices)
                {
                    if (headerIdx < rows.Count && col < rows[headerIdx].Count)
                    {
                        string value = rows[headerIdx][col];
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            headerValues.Add(value);
                        }
                    }
                }
                headerParts.Add(string.Join("_", headerValues));
            }

            string[] header = [.. headerParts];
            List<List<string>> body = [.. rows.Skip(Math.Min(maxHeaderIndex + 1, rows.Count))];

            if (x.Where is not null && x.Where.Count > 0)
            {
                foreach (WhereClause w in x.Where)
                {
                    int colIndex = Array.FindIndex(header, h => string.Equals(h, w.Column, StringComparison.Ordinal));
                    if (colIndex < 0)
                    {
                        continue;
                    }

                    body = [.. body.Where(r => ApplyWhere(r[colIndex], w))];
                }
            }

            if (x.Select is not null && x.Select.Count > 0)
            {
                string[] desired = [.. x.Select.OrderBy(s => s, StringComparer.Ordinal)];
                int[] idxMap = [.. desired.Select(col => Array.FindIndex(header, h => string.Equals(h, col, StringComparison.Ordinal)))];
                (int idx, int i)[] valid = [.. idxMap.Select((idx, i) => (idx, i)).Where(t => t.idx >= 0)];
                List<string> projHeader = [.. valid.Select(t => desired[t.i])];
                List<List<string>> projBody = [.. body.Select(row => valid.Select(t => row[t.idx]).ToList())];
                rows = [projHeader, .. projBody];
                header = [.. projHeader];
                body = projBody;
            }

            string locatorPrefix = $"extract:{x.Id}/sheet:{x.Sheet}";
            if (!string.IsNullOrEmpty(x.Table))
            {
                locatorPrefix += $"/table:{x.Table}";
            }

            if (!string.IsNullOrEmpty(x.Range))
            {
                locatorPrefix += $"/range:{x.Range}";
            }

            var payload = new { headerRowIndices, rows };
            //var env = dataEnvelopeBuilder.InitNew()
            //                             .WithDataShape(DataShape.Tabular)
            //                             .WithPayload(payload)
            //                             .WithMetadata(new Dictionary<string, string> { { "extractId", x.Id }, { "sheet", x.Sheet } })
            //                             .Build();
            parts.Add(dataPartBuilder.InitNew()
                                      .WithId(x.Id)
                                      .WithSource(sourceRefBuilder.InitNew().WithPath(sourcePath).WithLocator(locatorPrefix).Build())
                                      .WithLabel(x.Label)
                                      .WithPayload(payload)
                                      .WithTags(tagsBuilder.InitNew().AddRange(x.Tags).Build())
                                      .Build());
        }

        return context.Patch(b => b.WithDataEnvelope(dataEnvelopeBuilder.InitNew()
                                   .WithDataShape(DataShape.Linear)
                                   .WithParts(parts)
                                   .Build()))
                      .Success();
    }

    private static bool ApplyWhere(string value, WhereClause w)
    {
        string v = value ?? string.Empty;
        StringComparison cmp = StringComparison.Ordinal;
        return w.Op switch
        {
            "eq" => string.Equals(v, w.Value, cmp),
            "ne" => !string.Equals(v, w.Value, cmp),
            "neq" => !string.Equals(v, w.Value, cmp),
            "!=" => !string.Equals(v, w.Value, cmp),
            "in" => w.Value.Split('\u001f', StringSplitOptions.RemoveEmptyEntries).Contains(v),
            "contains" => v.Contains(w.Value, cmp),
            "gt" => string.Compare(v, w.Value, cmp) > 0,
            "lt" => string.Compare(v, w.Value, cmp) < 0,
            "gte" => string.Compare(v, w.Value, cmp) >= 0,
            "lte" => string.Compare(v, w.Value, cmp) <= 0,
            _ => true
        };
    }
}


