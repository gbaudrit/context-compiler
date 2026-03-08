namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    Configuration = 1000,
    Documents = 2000,
    FileReader = 3000,
    EngineeringModule = 4000,
    Transcoder = 5000,
    Guard = 6000,
    PromptComposer = 7000,
    View = 8000,
    Template = 9000,
    Persona = 10000,
    Validation = 11000,
    Compression = 12000,
    GraphExporter = 13000,
    Output = 14000,
    OutputArtifactComposer = 15000,
    OutputWriter = 16000,
    PromptRenderer = 17000,
}
