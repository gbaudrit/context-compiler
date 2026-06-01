using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Skills.Abstractions;

namespace ContextCompiler.Skills;

internal sealed record SkillInfos(string Id, string ProviderId, string BundleId, bool IsBundled, string Name, IStoreContainer RestoreCacheContainer) : ISkillInfos;
