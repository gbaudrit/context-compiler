using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Readers.Modules.Yaml;

public sealed class YamlFileReaderModule(ILinearFileReader linearFileReader) : IInputIngestionPipelineModule
{
    public InputIngestionModuleMetadata Metadata => IInputIngestionPipelineModule.Meta("readers.yaml", InputIngestionPipelineModuleKinds.ReadDocument, priority: 9);

    public bool CanProcess(IInputItemContext InputItemContext)
    {
        string ext = Path.GetExtension(InputItemContext.FullPath);
        return ext.Equals(".yaml", StringComparison.OrdinalIgnoreCase) || ext.Equals(".yml", StringComparison.OrdinalIgnoreCase);
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
