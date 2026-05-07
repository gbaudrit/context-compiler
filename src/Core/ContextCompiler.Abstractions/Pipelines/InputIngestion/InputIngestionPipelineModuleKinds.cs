namespace ContextCompiler.Abstractions.Pipelines.InputIngestion;

public enum InputIngestionPipelineModuleKinds
{
    None = 0,
    BeginProcess = 1000,
    ReadDocument = 2000,
    FileMatchTags = 3000,
    DiscoveryScopeGuards = 4000,
    ReadScopeGuards = 5000,
    BuildCompositeParts = 6000,
    DataPartsProcessor = 8000,
    FragmentsProcessor = 9000,
    EndProcess = 10000
}
