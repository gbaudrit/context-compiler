using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Modules.Abstractions;

public sealed record InputIngestionModuleMetadata(
    string Id,
    InputIngestionPipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
