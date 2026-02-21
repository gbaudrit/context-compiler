namespace ContextCompiler.Modules.Abstractions;

public sealed record ModuleMetadata(
    string Id,
    GlobalPipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
