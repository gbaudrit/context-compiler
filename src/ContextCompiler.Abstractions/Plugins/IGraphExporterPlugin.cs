namespace ContextCompiler.Abstractions.Plugins;

public interface IGraphExporterPlugin : IPlugin
{
    string FormatId { get; }
    string FileExtension { get; }
    string Export(object graphModel);
}
