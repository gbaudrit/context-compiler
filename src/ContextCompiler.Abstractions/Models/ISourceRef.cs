namespace ContextCompiler.Abstractions.Models
{
    public interface ISourceRef
    {
        string Id { get; }
        string Path { get; }
        string? Locator { get; }
    }
}
