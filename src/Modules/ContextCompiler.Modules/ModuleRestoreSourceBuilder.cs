using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules;

internal sealed class ModuleRestoreSourceBuilder : IModuleRestoreSourceBuilder
{
    internal sealed record ModuleRestoreSource : IModuleRestoreSource
    {
        public required string Id { get; init; }
    }

    private string? _id;

    public IModuleRestoreSourceBuilder InitNew()
    {
        _id = null;
        return this;
    }

    public IModuleRestoreSourceBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public IModuleRestoreSource Build()
    {
        return new ModuleRestoreSource
        {
            Id = _id ?? throw new InvalidOperationException("Id must be set before building.")
        };
    }
}
