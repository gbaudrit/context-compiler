using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.GlobalPipeline;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Modules.Abstractions.Views;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Modules.Loader;

public sealed class ModuleRegistryBuilder : IModuleRegistryBuilder
{
    public void RegisterModuleServices(IServiceCollection services, IEnumerable<Type> types)
    {
        _ = services.AddSingleton<IModulesRegistry>(sp => new ModulesRegistry(sp));


        foreach (Type t in types)
        {
            if (t is null || t.IsAbstract || t.IsInterface)
            {
                continue;
            }

            if (typeof(IDependencyInjection).IsAssignableFrom(t))
            {
                IDependencyInjection registration = (IDependencyInjection)Activator.CreateInstance(t)!;
                _ = registration.RegisterServices(services);
            }
            if (typeof(IGlobalPipelineModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IGlobalPipelineModule), t);
            }

            if (typeof(IDocumentPipelineModule).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(IDocumentPipelineModule), t));
            }

            if (typeof(IDocumentPartPipelineModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IDocumentPartPipelineModule), t);
            }

            if (typeof(IFileReaderModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IFileReaderModule), t);
            }

            if (typeof(IFileReader).IsAssignableFrom(t))
            {
                _ = services.AddTransient(t);
            }

            if (typeof(IDataReaderModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IDataReaderModule), t);
            }

            if (typeof(IEngineeringModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IEngineeringModule), t);
            }

            if (typeof(IFragmentProcessorModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IFragmentProcessorModule), t);
            }

            if (typeof(IViewModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewModule), t);
            }

            if (typeof(IViewRendererModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewRendererModule), t);
            }

            if (typeof(IViewDescriberModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewDescriberModule), t);
            }

            if (typeof(IViewRenderersModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewRenderersModule), t);
            }

            if (typeof(ITemplateModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(ITemplateModule), t);
            }

            if (typeof(IGraphExporterModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IGraphExporterModule), t);
            }

            if (typeof(IPersonaModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IPersonaModule), t);
            }
            if (typeof(IPromptComposerModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IPromptComposerModule), t);
            }

            if (typeof(IOutputArtifactSerializer).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IOutputArtifactSerializer), t);
            }

            if (typeof(IOutputArtifactsFilesWriterModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IOutputArtifactsFilesWriterModule), t);
            }

            if (typeof(IOutputArtifactComposerModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IOutputArtifactComposerModule), t);
            }

            if (typeof(IConfigurationModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IConfigurationModule), t);
            }
            if (typeof(IMCPListResourcesHandler).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IMCPListResourcesHandler), t);
            }
        }
    }
}
