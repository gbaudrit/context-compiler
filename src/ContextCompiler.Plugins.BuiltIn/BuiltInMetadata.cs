using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Plugins.BuiltIn;

public static class BuiltInMetadata
{
    public static PluginMetadata Meta(string id, GlobalPipelinePluginKinds kind, int priority = 0) =>
        new(id, kind, PluginApiVersion.Current, priority);
}
