using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Plugins.BuiltIn;

public static class BuiltInMetadata
{
    public static PluginMetadata Meta(string id, string kind, int priority = 0) =>
        new(id, kind, PluginApiVersion.Current, priority);
}
