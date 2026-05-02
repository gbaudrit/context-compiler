using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

namespace ContextCompiler.Modules.Abstractions;

public interface IModulesRegistry
{
    IReadOnlyList<IConfigurationModule> ConfigurationModules { get; }
    IReadOnlyList<IFileReaderModule> FileReaders { get; }
    IReadOnlyList<IDataReaderModule> DataReaders { get; }
    IReadOnlyList<IEngineeringModule> EngineeringModules { get; }
    IReadOnlyList<IViewModule> Views { get; }
    IReadOnlyList<ITemplateModule> Templates { get; }
    IReadOnlyList<IPromptRenderingModule> PromptRenderers { get; }
    IReadOnlyList<IGraphExporterModule> GraphExporters { get; }
    IReadOnlyList<IPersonaModule> Personas { get; }
    IReadOnlyList<IViewRendererModule> ViewRenderers { get; }
    IReadOnlyList<IPromptComposerModule> PromptComposers { get; }
    IReadOnlyList<IOutputArtifactsFilesWriterModule> OutputArtifactWriters { get; }
    IReadOnlyList<IOutputArtifactComposerModule> OutputArtifactComposers { get; }
    IReadOnlyList<IGlobalPipelineModule> GlobalPipelineModules { get; }
    IReadOnlyList<IDocumentPipelineModule> DocumentPipelineModules { get; }
    IReadOnlyList<IDocumentPartPipelineModule> DocumentPartPipelineModules { get; }
    IReadOnlyList<IFragmentProcessorModule> FragmentProcessors { get; }
    IReadOnlyList<IBlueprintComposerModule> Blueprints { get; }

    IEnumerable<T> GetModules<T>() where T : IModule;
}
