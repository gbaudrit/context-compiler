namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    Setup = 100000,
    InputDiscovery = 200000,
    InputIngestion = 300000,
    ContextProcessing = 400000,
    PolicyEnforcement = 500000,
    OutputComposition = 600000,
    OutputProjection = 700000,
    ReportComposition = 850000,
    ArtifactRendering = 900000,
    PrerequisitesEnrichment = 950000,
    ArtifactValidation = 970000,
    ArtifactPersistence = 1000000,
    PostProcessing = 1100000,
}
