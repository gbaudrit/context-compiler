namespace ContextCompiler.Modules.Abstractions.Pipelines.Analyze;

public sealed record AnalyzePipelineModuleMetadata(
    string Id,
    AnalyzePipelineModuleKinds Kind,
    int Priority = 0);
