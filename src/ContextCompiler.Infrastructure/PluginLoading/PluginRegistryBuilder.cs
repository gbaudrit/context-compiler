using System.Reflection;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Core.Pipelines;

namespace ContextCompiler.Infrastructure.PluginLoading;

public static class PluginRegistryBuilder
{
    public static PluginRegistry FromAssemblies(params Assembly[] assemblies)
    {
        var fileReaders = new List<IFileReaderPlugin>();
        var dataReaders = new List<IDataReaderPlugin>();
        var engineering = new List<IEngineeringModulePlugin>();
        var transcoders = new List<ITranscoderPlugin>();
        var guards = new List<IGuardPlugin>();
        var views = new List<IViewPlugin>();
        var templates = new List<ITemplatePlugin>();
        var exporters = new List<IGraphExporterPlugin>();

        foreach (var a in assemblies)
        {
            foreach (var t in a.GetTypes())
            {
                if (t.IsAbstract || t.IsInterface) continue;
                if (typeof(IFileReaderPlugin).IsAssignableFrom(t)) fileReaders.Add((IFileReaderPlugin)Activator.CreateInstance(t)!);
                if (typeof(IDataReaderPlugin).IsAssignableFrom(t)) dataReaders.Add((IDataReaderPlugin)Activator.CreateInstance(t)!);
                if (typeof(IEngineeringModulePlugin).IsAssignableFrom(t)) engineering.Add((IEngineeringModulePlugin)Activator.CreateInstance(t)!);
                if (typeof(ITranscoderPlugin).IsAssignableFrom(t)) transcoders.Add((ITranscoderPlugin)Activator.CreateInstance(t)!);
                if (typeof(IGuardPlugin).IsAssignableFrom(t)) guards.Add((IGuardPlugin)Activator.CreateInstance(t)!);
                if (typeof(IViewPlugin).IsAssignableFrom(t)) views.Add((IViewPlugin)Activator.CreateInstance(t)!);
                if (typeof(ITemplatePlugin).IsAssignableFrom(t)) templates.Add((ITemplatePlugin)Activator.CreateInstance(t)!);
                if (typeof(IGraphExporterPlugin).IsAssignableFrom(t)) exporters.Add((IGraphExporterPlugin)Activator.CreateInstance(t)!);
            }
        }

        return new PluginRegistry
        {
            FileReaders = fileReaders,
            DataReaders = dataReaders,
            EngineeringModules = engineering,
            Transcoders = transcoders,
            Guards = guards,
            Views = views,
            Templates = templates,
            GraphExporters = exporters
        };
    }
}
