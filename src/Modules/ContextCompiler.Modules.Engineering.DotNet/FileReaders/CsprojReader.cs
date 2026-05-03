using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Engineering.DotNet.FileReaders;

public sealed class TextFileReaderModule(IFileReadResultBuilder fileReadResultBuilder, IFileContentBuilder fileContentBuilder, ILinearFileReader linearFileReader, ILogger<TextFileReaderModule> logger) : IFileReaderModule
{
    public DocumentModuleMetadata Metadata => IDocumentPipelineModule.Meta("engineering.dotnet.filereader.csproj", DocumentPipelineModuleKinds.ReadDocument, priority: 10);

    private static readonly List<string> Extensions = [".csproj"];

    public bool CanProcess(IDocumentContext documentContext)
    {
        return Extensions.Contains(Path.GetExtension(documentContext.FullPath));
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
