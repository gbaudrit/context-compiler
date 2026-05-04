using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Readers.Modules.Text;

public sealed class TextFileReaderModule(ILinearFileReader linearFileReader, ILogger<TextFileReaderModule> logger) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("readers.text", DocumentPipelineModuleKinds.ReadDocument, priority: 0);

    private static readonly HashSet<string> Extensions =
    [
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".props"
    ];

    public bool CanProcess(IDocumentContext documentContext)
    {
        return Extensions.Contains(Path.GetExtension(documentContext.FullPath));
    }

    public async Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        logger.LogInformation("Reading text file: {Path}", context.Document.FullPath);

        IDataEnvelope envelope = await linearFileReader.ReadAsync(context.Document, ct);

        return await context.Patch(b => b.WithDataEnvelope(envelope)).Success();
    }
}
