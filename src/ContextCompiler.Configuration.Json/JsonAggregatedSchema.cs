using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json
{
    internal sealed record JsonAggregatedSchema : IAggregatedSchema
    {
        public required string Path { get; init; }
        public required string Name { get; init; }
        public required string Content { get; init; }
    }
}
