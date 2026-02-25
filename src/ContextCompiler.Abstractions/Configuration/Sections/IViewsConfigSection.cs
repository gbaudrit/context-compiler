namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface IViewsConfigSection
{
    bool? Inline { get; set; }
    IViewConfigSection[] Views { get; set; }
}
