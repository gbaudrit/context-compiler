namespace ContextCompiler.Abstractions.Models
{
    public interface ISourceRef
    {
        string Id { get; }
        Uri Uri { get; }
        string? Locator { get; }
    }
}
