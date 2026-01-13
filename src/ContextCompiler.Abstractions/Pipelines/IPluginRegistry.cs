using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.Prompts;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;

namespace ContextCompiler.Abstractions.Pipelines;

public interface IPluginRegistry
{
    IReadOnlyList<IFileReaderPlugin> FileReaders { get; }
    IReadOnlyList<IDataReaderPlugin> DataReaders { get; }
    IReadOnlyList<IEngineeringModulePlugin> EngineeringModules { get; }
    IReadOnlyList<ITranscoderPlugin> Transcoders { get; }
    IReadOnlyList<IGuardPlugin> Guards { get; }
    IReadOnlyList<IViewPlugin> Views { get; }
    IReadOnlyList<ITemplatePlugin> Templates { get; }
    IReadOnlyList<IPromptRenderingPlugin> PromptRenderers { get; }
    IReadOnlyList<IGraphExporterPlugin> GraphExporters { get; }
    IReadOnlyList<IPersonaPlugin> Personas { get; }
    IPlugins<IOutputPlugin> Outputs { get; }
    IReadOnlyList<IViewRendererPlugin> ViewRenderers { get; }
}
