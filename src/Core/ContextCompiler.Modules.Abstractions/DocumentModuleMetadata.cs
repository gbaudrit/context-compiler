using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Modules.Abstractions;

public sealed record DocumentModuleMetadata(
    string Id,
    DocumentPipelineModuleKinds Kind,
    int ApiVersion,
    int Priority = 0,
    IReadOnlyDictionary<string, string>? Capabilities = null
);
