using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Readers.Markdown;

public sealed class MarkdownFileReaderModule(ILinearFileReader linearFileReader) : IFileReaderModule
{
    public ModuleMetadata Metadata => IModule.Meta("readers.markdown", GlobalPipelineModuleKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        string ext = Path.GetExtension(path);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}
