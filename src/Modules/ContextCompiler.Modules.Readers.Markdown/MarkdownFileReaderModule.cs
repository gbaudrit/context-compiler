using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Readers.Markdown;

public sealed class MarkdownFileReaderModule(ILinearFileReader linearFileReader) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("readers.markdown", DocumentPipelineModuleKinds.ReadDocument, priority: 9);

    public bool CanProcess(IDocumentContext documentContext)
    {
        string ext = Path.GetExtension(documentContext.FullPath);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IDocumentContextPatch> Run(IDocumentContext documentContext, IDocumentContextPatchBuilder patcher, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, patcher, ct);
    }
}
