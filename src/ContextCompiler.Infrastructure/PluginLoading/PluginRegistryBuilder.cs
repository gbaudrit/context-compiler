using System.Reflection;
using ContextCompiler.Abstractions.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Infrastructure.PluginLoading;

public static class PluginRegistryBuilder
{
    public static void RegisterPluginServices(IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var a in assemblies)
        {
            foreach (var t in a.GetTypes())
            {
                if (t.IsAbstract || t.IsInterface) continue;
                if (typeof(IFileReaderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IFileReaderPlugin), t);
                if (typeof(IDataReaderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IDataReaderPlugin), t);
                if (typeof(IEngineeringModulePlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IEngineeringModulePlugin), t);
                if (typeof(ITranscoderPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(ITranscoderPlugin), t);
                if (typeof(IGuardPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IGuardPlugin), t);
                if (typeof(IViewPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IViewPlugin), t);
                if (typeof(ITemplatePlugin).IsAssignableFrom(t)) services.AddTransient(typeof(ITemplatePlugin), t);
                if (typeof(IGraphExporterPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IGraphExporterPlugin), t);
                if (typeof(IPersonaPlugin).IsAssignableFrom(t)) services.AddTransient(typeof(IPersonaPlugin), t);
            }
        }
    }
}
