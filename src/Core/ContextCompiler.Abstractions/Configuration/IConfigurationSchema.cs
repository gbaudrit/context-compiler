namespace ContextCompiler.Abstractions.Configuration
{
    public interface IConfigurationSchema
    {
        string Name { get; }

        string Content { get; }
    }
}
