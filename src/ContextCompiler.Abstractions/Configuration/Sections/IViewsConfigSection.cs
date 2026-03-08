namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface IViewsConfigSection
{
    bool? Inline { get; set; }
    List<IViewConfigSection> Views { get; }

    void AddView(IViewConfigSection viewConfig);
}
