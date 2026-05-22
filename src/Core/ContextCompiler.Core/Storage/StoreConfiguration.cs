using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Core.Storage;

internal sealed class StoreConfiguration : IStoreConfiguration
{
    public required string ParentId { get; init; }

    public required IStoreResourceUri Root { get; init; }

}
