using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Readers.Modules.Text;

public sealed class TextFileReaderModule(ILinearFileReader linearFileReader, ILogger<TextFileReaderModule> logger) : IFileReaderModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("readers.text", InputIngestionPipelineModuleKinds.ReadDocument, priority: 0);

    private static readonly HashSet<string> Extensions =
    [
        ".md",".txt",".cs",".json",".yaml",".yml",".xml",".config",".sln",".props"
    ];

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        return Extensions.Contains(Path.GetExtension(InputItemContext.FullPath));
    }

    public async Task<IResult<IInputIngestionPipelineRunResult>> Run(IInputIngestionPipelineRunContext context, CancellationToken ct)
    {
        logger.LogInformation("Reading text file: {Path}", context.InputItem.FullPath);

        IDataEnvelope envelope = await linearFileReader.ReadAsync(context.InputItem, ct);

        return await context.Patch(b => b.WithDataEnvelope(envelope)).Success();
    }
}
