namespace ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

public sealed record PreparePipelineModuleMetadata(
    string Id,
    PreparePipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
