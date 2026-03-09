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
    Persona = 9000,
    Validation = 10000,
    Compression = 11000,
    GraphExporter = 12000,
    Output = 13000,
    OutputArtifactComposer = 14000,
    Template = 15000,
    OutputWriter = 16000,
    PromptRenderer = 17000
}
