using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

namespace ContextCompiler.Modules.Abstractions;

public interface IModulesRegistry
{
    IReadOnlyList<IConfigurationModule> ConfigurationModules { get; }
    IReadOnlyList<IDataReaderModule> DataReaders { get; }
    IReadOnlyList<IEngineeringModule> EngineeringModules { get; }
    IReadOnlyList<IViewModule> Views { get; }
    IReadOnlyList<IPromptRenderingModule> PromptRenderers { get; }
    IReadOnlyList<IGraphExporterModule> GraphExporters { get; }
    IReadOnlyList<IViewRendererModule> ViewRenderers { get; }
    IReadOnlyList<ICompilePipelineModule> CompilePipelineModules { get; }
    IReadOnlyList<IInputIngestionPipelineModule> InputIngestionPipelineModules { get; }
    IReadOnlyList<IDataPartPipelineModule> DataPartPipelineModules { get; }
    IReadOnlyList<IFragmentProcessorModule> FragmentProcessors { get; }

    IEnumerable<T> GetModules<T>() where T : IModule;
}
