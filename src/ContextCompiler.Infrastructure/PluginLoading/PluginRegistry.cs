using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Plugins.Prompts;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.PluginLoading;

public sealed class PluginRegistry : IPluginRegistry
{
    private readonly IServiceProvider _services;

    public PluginRegistry(IServiceProvider services)
    {
        _services = services;
    }

    public IReadOnlyList<IFileReaderPlugin> FileReaders => _services.GetServices<IFileReaderPlugin>().ToList();
    public IReadOnlyList<IDataReaderPlugin> DataReaders => _services.GetServices<IDataReaderPlugin>().ToList();
    public IReadOnlyList<IEngineeringModulePlugin> EngineeringModules => _services.GetServices<IEngineeringModulePlugin>().ToList();
    public IReadOnlyList<ITranscoderPlugin> Transcoders => _services.GetServices<ITranscoderPlugin>().ToList();
    public IReadOnlyList<IGuardPlugin> Guards => _services.GetServices<IGuardPlugin>().ToList();
    public IReadOnlyList<IViewPlugin> Views => _services.GetServices<IViewPlugin>().ToList();
    public IReadOnlyList<IViewRendererPlugin> ViewRenderers => _services.GetServices<IViewRendererPlugin>().ToList();
    public IReadOnlyList<ITemplatePlugin> Templates => _services.GetServices<ITemplatePlugin>().ToList();
    public IReadOnlyList<IPromptRenderingPlugin> PromptRenderers => _services.GetServices<IPromptRenderingPlugin>().ToList();
    public IReadOnlyList<IPromptComposerPlugin> PromptComposers => _services.GetServices<IPromptComposerPlugin>().ToList();
    public IReadOnlyList<IGraphExporterPlugin> GraphExporters => _services.GetServices<IGraphExporterPlugin>().ToList();
    public IReadOnlyList<IPersonaPlugin> Personas => _services.GetServices<IPersonaPlugin>().ToList();
    //public IPlugins<IOutputPlugin> Outputs => _services.GetRequiredService<IPlugins<IOutputPlugin>>();
    public IReadOnlyList<IOutputArtifactsFilesWriterPlugin> OutputArtifactWriters => _services.GetServices<IOutputArtifactsFilesWriterPlugin>().ToList();
    public IReadOnlyList<IOutputArtifactComposerPlugin> OutputArtifactComposers => _services.GetServices<IOutputArtifactComposerPlugin>().ToList();
}
