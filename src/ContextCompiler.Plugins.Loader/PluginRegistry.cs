using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.GlobalPipeline;
using ContextCompiler.Plugins.Abstractions.Prompts;
using ContextCompiler.Plugins.Abstractions.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Plugins.Loader;

public sealed class PluginRegistry(IServiceProvider services) : IPluginRegistry
{
    private readonly IServiceProvider _services = services;

    public IReadOnlyList<IGlobalPipelinePlugin> GlobalPipelinePlugins => [.. _services.GetServices<IGlobalPipelinePlugin>()];

    public IReadOnlyList<IFileReaderPlugin> FileReaders => [.. _services.GetServices<IFileReaderPlugin>()];
    public IReadOnlyList<IDataReaderPlugin> DataReaders => [.. _services.GetServices<IDataReaderPlugin>()];
    public IReadOnlyList<IEngineeringModulePlugin> EngineeringModules => [.. _services.GetServices<IEngineeringModulePlugin>()];
    public IReadOnlyList<ITranscoderPlugin> Transcoders => [.. _services.GetServices<ITranscoderPlugin>()];
    public IReadOnlyList<IGuardPlugin> Guards => [.. _services.GetServices<IGuardPlugin>()];
    public IReadOnlyList<IViewPlugin> Views => [.. _services.GetServices<IViewPlugin>()];
    public IReadOnlyList<IViewRendererPlugin> ViewRenderers => [.. _services.GetServices<IViewRendererPlugin>()];
    public IReadOnlyList<ITemplatePlugin> Templates => [.. _services.GetServices<ITemplatePlugin>()];
    public IReadOnlyList<IPromptRenderingPlugin> PromptRenderers => [.. _services.GetServices<IPromptRenderingPlugin>()];
    public IReadOnlyList<IPromptComposerPlugin> PromptComposers => [.. _services.GetServices<IPromptComposerPlugin>()];
    public IReadOnlyList<IGraphExporterPlugin> GraphExporters => [.. _services.GetServices<IGraphExporterPlugin>()];
    public IReadOnlyList<IPersonaPlugin> Personas => [.. _services.GetServices<IPersonaPlugin>()];
    //public IPlugins<IOutputPlugin> Outputs => _services.GetRequiredService<IPlugins<IOutputPlugin>>();
    public IReadOnlyList<IOutputArtifactsFilesWriterPlugin> OutputArtifactWriters => [.. _services.GetServices<IOutputArtifactsFilesWriterPlugin>()];
    public IReadOnlyList<IOutputArtifactComposerPlugin> OutputArtifactComposers => [.. _services.GetServices<IOutputArtifactComposerPlugin>()];
}
