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
        services.AddSingleton<IPluginRegistry>(sp => new PluginRegistry(sp));
        foreach (var a in assemblies)
        {
            foreach (var t in a.GetTypes())
            {
                if (t.IsAbstract || t.IsInterface) continue;
                if(typeof(IPluginRegistration).IsAssignableFrom(t))
                {
                    var registration = (IPluginRegistration)Activator.CreateInstance(t)!;
                    registration.RegisterServices(services);
                }
                if (typeof(IFileReaderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IFileReaderPlugin), t);
                if (typeof(IFileReader).IsAssignableFrom(t)) services.AddTransient(t);
                if (typeof(IDataReaderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IDataReaderPlugin), t);
                if (typeof(IEngineeringModulePlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IEngineeringModulePlugin), t);
                if (typeof(ITranscoderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(ITranscoderPlugin), t);
                if (typeof(IGuardPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IGuardPlugin), t);
                if (typeof(IViewPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IViewPlugin), t);
                if (typeof(IViewRendererPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IViewRendererPlugin), t);
                if (typeof(IViewRenderersPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IViewRenderersPlugin), t);
                if (typeof(ITemplatePlugin).IsAssignableFrom(t)) services.AddTransient(typeof(ITemplatePlugin), t);
                if (typeof(IGraphExporterPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IGraphExporterPlugin), t);
                if (typeof(IPersonaPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IPersonaPlugin), t);
                //if (typeof(IOutputPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IOutputPlugin), t);
                if (typeof(IPromptComposerPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IPromptComposerPlugin), t);
                if (typeof(IOutputArtifactsFilesWriterPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IOutputArtifactsFilesWriterPlugin), t);
                if (typeof(IOutputArtifactComposerPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IOutputArtifactComposerPlugin), t);
            }
        }
    }
}
