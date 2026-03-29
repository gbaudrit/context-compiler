using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Core.Configuration
{
    internal sealed record Schema : ISchema
    {

        public required string Path { get; init; }
        public required string Name { get; init; }
        public required string Content { get; init; }

    }
}
