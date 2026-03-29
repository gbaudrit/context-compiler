namespace ContextCompiler.Modules.Abstractions;

public interface IGraphExporterModule : IModule
{
    string FormatId { get; }
    string FileExtension { get; }
    string Export(object graphModel);
}
