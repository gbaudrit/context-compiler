namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    Configuration = 1000,
    InputsProcessing = 2000,
    EngineeringModule = 4000,
    Guard = 7000,
    PromptComposer = 8000,
    Views = 9000,
    Persona = 10000,
    Validation = 11000,
    Compression = 12000,
    GraphExporter = 13000,
    Output = 14000,
    OutputArtifactComposer = 15000,
    Template = 16000,
    OutputWriter = 17000,
    PromptRenderer = 18000,
    EndTools = 19000
}
