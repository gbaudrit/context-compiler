namespace ContextCompiler.Modules.Abstractions;

public sealed record ViewModuleMetadata(
    string Id,
    ViewModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
