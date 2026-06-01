using ContextCompiler.Abstractions.Storage;

namespace ContextCompiler.Skills.Abstractions;

public interface ISkillInfosBuilder
{
    ISkillInfosBuilder InitNew();

    ISkillInfos Build();
    ISkillInfosBuilder WithBundleId(string bundleId);
    ISkillInfosBuilder WithId(string id);
    ISkillInfosBuilder WithName(string name);
    ISkillInfosBuilder WithProviderId(string providerId);
    ISkillInfosBuilder WithRestoreCacheContainer(IStoreContainer restoreCacheContainer);
}
