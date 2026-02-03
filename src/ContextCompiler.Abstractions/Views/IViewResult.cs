namespace ContextCompiler.Abstractions.Views
{
    public interface IViewResult
    {
        string ViewId { get; }
        string Title { get; }
        string Filename { get; }
        string Content { get; }
        string Mime { get; }
        IReadOnlyDictionary<string, string>? Metadata { get; }
    }
}
