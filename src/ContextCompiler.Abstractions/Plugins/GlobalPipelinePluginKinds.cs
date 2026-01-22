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
    View = 6000,
    Template = 7000,
    Persona = 8000,
    Validation = 9000,
    Compression = 10000,
    GraphExporter = 11000,
    Output = 12000,
    OutputWriter = 13000,
    OutputArtifactComposer = 14000,
    PromptComposer = 15000,
    PromptRenderer = 16000,
}
