
namespace ContextCompiler.Abstractions.Views
{
    public interface IViewResultBuilder
    {
        IViewResultBuilder InitNew();
        IViewResultBuilder WithFilename(string filename);
        IViewResultBuilder WithMetadata(IReadOnlyDictionary<string, string> metadata);
        IViewResultBuilder WithMime(string mime);
        IViewResultBuilder WithId(string viewId);
        IViewResultBuilder WithTitle(string title);
        IViewResult Build();
        IViewResultBuilder WithContent(string content);
        IViewResultBuilder WithRendererType(Type rendererType);
    }
}
