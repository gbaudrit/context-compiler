using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Abstractions.Plugins;

public interface IPlugin
{
    static PluginMetadata Meta(string id, GlobalPipelinePluginKinds kind, int priority = 0)
    {
        return new(id, kind, PluginApiVersion.Current, priority);
    }

    PluginMetadata Metadata { get; }


}
