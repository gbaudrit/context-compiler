using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Prompting.Modules.Engineering.DotNet.FileReaders;

public sealed class TextFileReaderModule(
    IFileReadResultBuilder fileReadResultBuilder,
    IFileContentBuilder fileContentBuilder,
    ILinearFileReader linearFileReader,
    ILogger<TextFileReaderModule> logger) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("engineering.dotnet.filereader.csproj", InputIngestionPipelineModuleKinds.ReadSource, priority: 10);

    private static readonly List<string> Extensions = [".csproj"];

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return Extensions.Contains(Path.GetExtension(InputItemContext.Uri.AbsolutePath));
    }

    public async Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        IDataEnvelope envelope = await linearFileReader.ReadAsync(context.InputItem, ct);

        return await context.Patch(b =>
        {
            _ = b.WithDataEnvelope(envelope);
        }).Success();
    }
}
