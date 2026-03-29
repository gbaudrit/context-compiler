using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules
{
    internal sealed record ModuleRestoreSource : IModuleRestoreSource
    {

        public required string Id { get; init; }

    }
}
