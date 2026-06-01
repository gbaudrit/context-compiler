using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputContext : IOutputContext
    {
        public required string OutputPath { get; set; }
    }
}
