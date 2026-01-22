namespace ContextCompiler.Abstractions.Plugins;

public sealed record PluginMetadata(
    string Id,
    GlobalPipelinePluginKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
