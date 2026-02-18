namespace ContextCompiler.Abstractions.Configuration;

public interface IViewsConfig
{
    bool? Inline { get; set; }
    IViewConfig[] Views { get; set; }
}
