using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Readers.Text;

public sealed class TextFileReaderModule(ILinearFileReader linearFileReader, ILogger<TextFileReaderModule> logger) : IFileReaderModule
{
    public ModuleMetadata Metadata => IModule.Meta("readers.text", GlobalPipelineModuleKinds.FileReader, priority: 0);

    private static readonly HashSet<string> Extensions =
    [
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".props"
    ];

    public bool CanRead(string path)
    {
        return Extensions.Contains(Path.GetExtension(path));
    }

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        logger.LogInformation("Reading text file: {Path}", documentContext.FullPath);
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}
