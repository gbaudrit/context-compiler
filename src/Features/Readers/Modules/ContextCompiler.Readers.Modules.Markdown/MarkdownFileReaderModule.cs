using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Readers.Modules.Markdown;

public sealed class MarkdownFileReaderModule(ILinearFileReader linearFileReader) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("readers.markdown", InputIngestionPipelineModuleKinds.ReadSource, priority: 9);

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        string ext = Path.GetExtension(InputItemContext.Uri.AbsolutePath);
        return ext.Equals(".md", StringComparison.OrdinalIgnoreCase) || ext.Equals(".markdown", StringComparison.OrdinalIgnoreCase);
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
