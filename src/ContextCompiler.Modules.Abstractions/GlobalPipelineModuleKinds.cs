namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    FileReader = 1000,
    DataReader = 2000,
    EngineeringModule = 3000,
    Transcoder = 4000,
    Guard = 5000,
    PromptComposer = 6000,
    View = 7000,
    Template = 8000,
    Persona = 9000,
    Validation = 10000,
    Compression = 11000,
    GraphExporter = 12000,
    Output = 13000,
    OutputArtifactComposer = 14000,
    OutputWriter = 15000,
    PromptRenderer = 16000,
}
