namespace ContextCompiler.Abstractions.Pipelines.Document;

public sealed record DocumentPassMetadata(
    string Id,
    DocumentPipelineModuleKinds Kind,
    DocumentStage Stage,
    int Priority = 0
);
