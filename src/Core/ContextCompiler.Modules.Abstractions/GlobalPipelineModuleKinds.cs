namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    Setup = 10000,
    InputDiscovery = 20000,
    InputIngestion = 30000,
    ContextProcessing = 40000,
    PolicyEnforcement = 50000,
    OutputComposition = 60000,
    OutputProjection = 70000,
    ReportComposition = 85000,
    ArtifactRendering = 90000,
    ArtifactPersistence = 100000,
    PostProcessing = 110000,
}
