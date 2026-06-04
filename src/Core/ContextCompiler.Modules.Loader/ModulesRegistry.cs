using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Modules.Loader;

public sealed class ModulesRegistry(IServiceProvider services) : IModulesRegistry
{
    private readonly IServiceProvider _services = services;

    public IReadOnlyList<ICompilePipelineModule> CompilePipelineModules => [.. _services.GetServices<ICompilePipelineModule>()];
    public IReadOnlyList<IInputIngestionPipelineModule> InputIngestionPipelineModules => [.. _services.GetServices<IInputIngestionPipelineModule>()];
    public IReadOnlyList<IDataPartPipelineModule> DataPartPipelineModules => [.. _services.GetServices<IDataPartPipelineModule>()];
    public IReadOnlyList<IPreparePipelineModule> PreparePipelineModules => [.. _services.GetServices<IPreparePipelineModule>()];

    public IReadOnlyList<IDataReaderModule> DataReaders => [.. _services.GetServices<IDataReaderModule>()];
    public IReadOnlyList<IEngineeringModule> EngineeringModules => [.. _services.GetServices<IEngineeringModule>()];
    public IReadOnlyList<IViewModule> Views => [.. _services.GetServices<IViewModule>()];
    public IReadOnlyList<IViewRendererModule> ViewRenderers => [.. _services.GetServices<IViewRendererModule>()];
    public IReadOnlyList<IPromptRenderingModule> PromptRenderers => [.. _services.GetServices<IPromptRenderingModule>()];
    public IReadOnlyList<IGraphExporterModule> GraphExporters => [.. _services.GetServices<IGraphExporterModule>()];
    public IReadOnlyList<IConfigurationModule> ConfigurationModules => [.. _services.GetServices<IConfigurationModule>()];
    public IReadOnlyList<IFragmentProcessorModule> FragmentProcessors => [.. _services.GetServices<IFragmentProcessorModule>()];

    public IEnumerable<T> GetModules<T>() where T : IModule
    {
        return _services.GetServices<T>();
    }
}
