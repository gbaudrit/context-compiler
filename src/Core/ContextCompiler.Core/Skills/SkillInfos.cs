using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Skills;

namespace ContextCompiler.Core.Skills;

internal sealed record SkillInfos(string Id, string ProviderId, string BundleId, bool IsBundled, string Name, IStoreContainer RestoreCacheContainer) : ISkillInfos;
