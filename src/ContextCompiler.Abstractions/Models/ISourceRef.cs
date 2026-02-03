namespace ContextCompiler.Abstractions.Models
{
    public interface ISourceRef
    {
        string Path { get; }
        string? Locator { get; }
    }
}
