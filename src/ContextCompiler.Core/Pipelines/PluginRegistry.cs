using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Core.Pipelines;

public sealed class PluginRegistry : IPluginRegistry
{
    public IReadOnlyList<IFileReaderPlugin> FileReaders { get; init; } = Array.Empty<IFileReaderPlugin>();
    public IReadOnlyList<IDataReaderPlugin> DataReaders { get; init; } = Array.Empty<IDataReaderPlugin>();
    public IReadOnlyList<IEngineeringModulePlugin> EngineeringModules { get; init; } = Array.Empty<IEngineeringModulePlugin>();
    public IReadOnlyList<ITranscoderPlugin> Transcoders { get; init; } = Array.Empty<ITranscoderPlugin>();
    public IReadOnlyList<IGuardPlugin> Guards { get; init; } = Array.Empty<IGuardPlugin>();
    public IReadOnlyList<IViewPlugin> Views { get; init; } = Array.Empty<IViewPlugin>();
    public IReadOnlyList<ITemplatePlugin> Templates { get; init; } = Array.Empty<ITemplatePlugin>();
    public IReadOnlyList<IGraphExporterPlugin> GraphExporters { get; init; } = Array.Empty<IGraphExporterPlugin>();
}
