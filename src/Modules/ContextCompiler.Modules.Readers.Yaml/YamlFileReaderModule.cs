using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Readers.Yaml;

public sealed class YamlFileReaderModule(ILinearFileReader linearFileReader) : IFileReaderModule
{
    public ModuleMetadata Metadata => IModule.Meta("readers.yaml", GlobalPipelineModuleKinds.FileReader, priority: 9);

    public bool CanRead(string path)
    {
        string ext = Path.GetExtension(path);
        return ext.Equals(".yaml", StringComparison.OrdinalIgnoreCase) || ext.Equals(".yml", StringComparison.OrdinalIgnoreCase);
    }

    public async Task<IDataEnvelope> ReadAsync(IDocumentContext documentContext, CancellationToken ct)
    {
        return await linearFileReader.ReadAsync(documentContext, ct);
    }
}
