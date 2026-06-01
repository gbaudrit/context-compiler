namespace ContextCompiler.Abstractions.Configuration
{
    public interface ISchema
    {
        string Name { get; init; }
        string Content { get; init; }
        string Path { get; init; }
    }
}
