using ContextCompiler.Plugins.Abstractions.GlobalPipeline;
using ContextCompiler.Plugins.Abstractions.Prompts;
using ContextCompiler.Plugins.Abstractions.Views.Renderers;

namespace ContextCompiler.Plugins.Abstractions;

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
    //IPlugins<IOutputPlugin> Outputs { get; }
    IReadOnlyList<IViewRendererPlugin> ViewRenderers { get; }
    IReadOnlyList<IPromptComposerPlugin> PromptComposers { get; }
    IReadOnlyList<IOutputArtifactsFilesWriterPlugin> OutputArtifactWriters { get; }
    IReadOnlyList<IOutputArtifactComposerPlugin> OutputArtifactComposers { get; }
    IReadOnlyList<IGlobalPipelinePlugin> GlobalPipelinePlugins { get; }
}
