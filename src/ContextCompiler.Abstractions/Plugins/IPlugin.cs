using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Abstractions.Plugins;

public interface IPlugin
{
    public static PluginMetadata Meta(string id, GlobalPipelinePluginKinds kind, int priority = 0) =>
        new(id, kind, PluginApiVersion.Current, priority);

    PluginMetadata Metadata { get; }

    
}
