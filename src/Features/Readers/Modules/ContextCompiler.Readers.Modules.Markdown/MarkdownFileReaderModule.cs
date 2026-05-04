using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Readers.Modules.Markdown;

public sealed class MarkdownFileReaderModule(ILinearFileReader linearFileReader) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("readers.markdown", DocumentPipelineModuleKinds.ReadDocument, priority: 9);

    public bool CanProcess(IDocumentContext documentContext)
    {
        string ext = Path.GetExtension(documentContext.FullPath);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IResult<IDocumentPipelineRunResult>> Run(IDocumentPipelineRunContext context, CancellationToken ct)
    {
        IDataEnvelope envelope = await linearFileReader.ReadAsync(context.Document, ct);

        return await context.Patch(b =>
        {
            _ = b.WithDataEnvelope(envelope);
        }).Success();
    }
}
