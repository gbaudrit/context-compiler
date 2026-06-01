using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Skills.Abstractions;

public interface ISkillInfos
{
    string Id { get; }
    string BundleId { get; }
    bool IsBundled { get; }

    string Name { get; }

    IStoreContainer RestoreCacheContainer { get; }
}
