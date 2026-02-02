using System.Reflection;

using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.PluginLoading;

public static class PluginRegistryBuilder
{
    public static void RegisterPluginServices(IServiceCollection services, params Assembly[] assemblies)
    {
        _ = services.AddSingleton<IPluginRegistry>(sp => new PluginRegistry(sp));
        foreach (Assembly a in assemblies)
        {
            foreach (Type t in a.GetTypes())
            {
                if (t.IsAbstract || t.IsInterface)
                {
                    continue;
                }

                if (typeof(IPluginRegistration).IsAssignableFrom(t))
                {
                    IPluginRegistration registration = (IPluginRegistration)Activator.CreateInstance(t)!;
                    _ = registration.RegisterServices(services);
                }
                if (typeof(IGlobalPipelinePlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IGlobalPipelinePlugin), t);
                }

                if (typeof(IFileReaderPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IFileReaderPlugin), t);
                }

                if (typeof(IFileReader).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(t);
                }

                if (typeof(IDataReaderPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IDataReaderPlugin), t);
                }

                if (typeof(IEngineeringModulePlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IEngineeringModulePlugin), t);
                }

                if (typeof(ITranscoderPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(ITranscoderPlugin), t);
                }

                if (typeof(IGuardPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IGuardPlugin), t);
                }

                if (typeof(IViewPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IViewPlugin), t);
                }

                if (typeof(IViewRendererPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IViewRendererPlugin), t);
                }

                if (typeof(IViewRenderersPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IViewRenderersPlugin), t);
                }

                if (typeof(ITemplatePlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(ITemplatePlugin), t);
                }

                if (typeof(IGraphExporterPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IGraphExporterPlugin), t);
                }

                if (typeof(IPersonaPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IPersonaPlugin), t);
                }
                //if (typeof(IOutputPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IOutputPlugin), t);
                if (typeof(IPromptComposerPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IPromptComposerPlugin), t);
                }

                if (typeof(IOutputArtifactsFilesWriterPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IOutputArtifactsFilesWriterPlugin), t);
                }

                if (typeof(IOutputArtifactComposerPlugin).IsAssignableFrom(t))
                {
                    _ = services.AddTransient(typeof(IOutputArtifactComposerPlugin), t);
                }
            }
        }
    }
}
