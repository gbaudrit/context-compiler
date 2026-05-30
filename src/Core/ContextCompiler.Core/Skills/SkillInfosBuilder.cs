using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions.Skills;

namespace ContextCompiler.Core.Skills;

internal sealed class SkillInfosBuilder : ISkillInfosBuilder
{

    private string? _id;
    private string? _providerId;
    private string? _bundleId;
    private string? _name;
    private IStoreContainer? _restoreCacheContainer;

    public ISkillInfosBuilder InitNew()
    {
        _id = null;
        _name = null;
        _providerId = null;
        _bundleId = null;
        _restoreCacheContainer = null;
        return this;
    }

    public ISkillInfosBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public ISkillInfosBuilder WithProviderId(string providerId)
    {
        _providerId = providerId;
        return this;
    }


    public ISkillInfosBuilder WithBundleId(string bundleId)
    {
        _bundleId = bundleId;
        return this;
    }

    public ISkillInfosBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISkillInfosBuilder WithRestoreCacheContainer(IStoreContainer restoreCacheContainer)
    {
        _restoreCacheContainer = restoreCacheContainer;
        return this;
    }

    public ISkillInfos Build()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(_id, nameof(_id));
        ArgumentException.ThrowIfNullOrWhiteSpace(_providerId, nameof(_providerId));
        ArgumentException.ThrowIfNullOrWhiteSpace(_name, nameof(_name));

        return new SkillInfos(_id,
                              _providerId,
                              _bundleId ?? "",
                              !string.IsNullOrEmpty(_bundleId),
                              _name,
                              _restoreCacheContainer ?? throw new ArgumentNullException(nameof(_restoreCacheContainer)));
    }

}
