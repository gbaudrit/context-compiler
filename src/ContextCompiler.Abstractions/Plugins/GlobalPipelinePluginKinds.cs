namespace ContextCompiler.Abstractions.Plugins;

//public static class PluginKinds
//{
//    public const string FileReader = "FileReader";
//    public const string DataReader = "DataReader";
//    public const string EngineeringModule = "EngineeringModule";
//    public const string Transcoder = "Transcoder";
//    public const string Guard = "Guard";
//    public const string View = "View";
//    public const string Template = "Template";
//    public const string Persona = "Persona";
//    public const string Validation = "Validation";
//    public const string Compression = "Compression";
//    public const string GraphExporter = "GraphExporter";
//    public const string Output = "Output";
//    public const string OutputWriter = "OutputWriter";
//    public const string OutputArtifactComposer = "OutputArtifactComposer";
//    public const string PromptComposer = "PromptComposer";
//    public const string PromptRenderer = "PromptRenderer";
//}

public enum GlobalPipelinePluginKinds
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
