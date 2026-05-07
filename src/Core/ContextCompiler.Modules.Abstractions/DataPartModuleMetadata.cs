using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Modules.Abstractions;

public sealed record DataPartModuleMetadata(
    string Id,
    DataPartPipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
