using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Modules.Abstractions;

public sealed record ModuleMetadata(
    string Id,
    CompilePipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
