using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json;

internal sealed record ConfigurationSchema : IConfigurationSchema
{
    public required string Name { get; init; }
    public required string Content { get; init; }
}
