using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Loader;

public sealed class ModulesRegistry(IServiceProvider services) : IModulesRegistry
{
    private readonly IServiceProvider _services = services;

    public IReadOnlyList<IGlobalPipelineModule> GlobalPipelineModules => [.. _services.GetServices<IGlobalPipelineModule>()];
    public IReadOnlyList<IDocumentPipelineModule> DocumentPipelineModules => [.. _services.GetServices<IDocumentPipelineModule>()];
    public IReadOnlyList<IDocumentPartPipelineModule> DocumentPartPipelineModules => [.. _services.GetServices<IDocumentPartPipelineModule>()];

    public IReadOnlyList<IFileReaderModule> FileReaders => [.. _services.GetServices<IFileReaderModule>()];
    public IReadOnlyList<IDataReaderModule> DataReaders => [.. _services.GetServices<IDataReaderModule>()];
    public IReadOnlyList<IEngineeringModule> EngineeringModules => [.. _services.GetServices<IEngineeringModule>()];
    public IReadOnlyList<IViewModule> Views => [.. _services.GetServices<IViewModule>()];
    public IReadOnlyList<IViewRendererModule> ViewRenderers => [.. _services.GetServices<IViewRendererModule>()];
    public IReadOnlyList<ITemplateModule> Templates => [.. _services.GetServices<ITemplateModule>()];
    public IReadOnlyList<IPromptRenderingModule> PromptRenderers => [.. _services.GetServices<IPromptRenderingModule>()];
    public IReadOnlyList<IPromptComposerModule> PromptComposers => [.. _services.GetServices<IPromptComposerModule>()];
    public IReadOnlyList<IGraphExporterModule> GraphExporters => [.. _services.GetServices<IGraphExporterModule>()];
    public IReadOnlyList<IPersonaModule> Personas => [.. _services.GetServices<IPersonaModule>()];
    public IReadOnlyList<IOutputArtifactsFilesWriterModule> OutputArtifactWriters => [.. _services.GetServices<IOutputArtifactsFilesWriterModule>()];
    public IReadOnlyList<IOutputArtifactComposerModule> OutputArtifactComposers => [.. _services.GetServices<IOutputArtifactComposerModule>()];
    public IReadOnlyList<IDocumentsModule> DocumentsModules => [.. _services.GetServices<IDocumentsModule>()];
    public IReadOnlyList<IConfigurationModule> ConfigurationModules => [.. _services.GetServices<IConfigurationModule>()];
    public IReadOnlyList<IFragmentProcessorModule> FragmentProcessors => [.. _services.GetServices<IFragmentProcessorModule>()];
    public IReadOnlyList<IBlueprintComposerModule> Blueprints => [.. _services.GetServices<IBlueprintComposerModule>()];

    public IEnumerable<T> GetModules<T>() where T : IModule
    {
        return _services.GetServices<T>();
    }
}
