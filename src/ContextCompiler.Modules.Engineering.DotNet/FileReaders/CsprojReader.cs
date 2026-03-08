using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Engineering.DotNet.FileReaders;

public sealed class TextFileReaderModule(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ILinearFileReader linearFileReader, ILogger<TextFileReaderModule> logger) : IFileReaderModule
{
    public ModuleMetadata Metadata => IModule.Meta("engineering.dotnet.filereader.csproj", GlobalPipelineModuleKinds.FileReader, priority: 10);

    private static readonly HashSet<string> Extensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".csproj"
    };

    public bool CanRead(string path)
    {
        return Extensions.Contains(Path.GetExtension(path));
    }

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}
