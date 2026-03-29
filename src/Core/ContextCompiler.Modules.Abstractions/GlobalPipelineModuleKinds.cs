namespace ContextCompiler.Modules.Abstractions;

public enum GlobalPipelineModuleKinds
{
    Configuration = 1000,
    Documents = 2000,
    FileReader = 3000,
    EngineeringModule = 4000,
    Transcoder = 5000,
    FragmentProcessor = 6000,
    Guard = 7000,
    PromptComposer = 8000,
    View = 9000,
    Persona = 10000,
    Validation = 11000,
    Compression = 12000,
    GraphExporter = 13000,
    Output = 14000,
    OutputArtifactComposer = 15000,
    Template = 16000,
    OutputWriter = 17000,
    PromptRenderer = 18000
}
