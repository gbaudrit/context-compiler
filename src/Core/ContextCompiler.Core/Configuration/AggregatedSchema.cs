using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Core.Configuration
{
    public sealed record AggregatedSchema : IAggregatedSchema
    {
        public required string Name { get; init; }
        public required string Content { get; init; }
        public required string Path { get; init; }

    }
}
