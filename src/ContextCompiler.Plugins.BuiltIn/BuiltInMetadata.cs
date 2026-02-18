using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Plugins.Abstractions;

namespace ContextCompiler.Plugins.BuiltIn;

public static class BuiltInMetadata
{
    public static PluginMetadata Meta(string id, GlobalPipelinePluginKinds kind, int priority = 0)
    {
        return new(id, kind, PluginApiVersion.Current, priority);
    }
}
