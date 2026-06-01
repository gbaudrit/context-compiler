using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Core.Pipelines.DataPart;

internal sealed class DataPartDescriptorBuilder : IDataPartDescriptorBuilder
{
    private DataPartType? _type;
    private string? _name;
    private string? _category;
    private DataPartAgentContextAction? _defaultAgentContextAction;
    private DataPartTransformationMode? _recommendedTransformation;
    private DataPartTraits? _traits;
    private string? _description;

    public IDataPartDescriptorBuilder InitNew()
    {
        _type = null;
        _name = null;
        _category = null;
        _defaultAgentContextAction = null;
        _recommendedTransformation = null;
        _traits = null;
        _description = null;
        return this;
    }

    public IDataPartDescriptorBuilder WithType(DataPartType type)
    {
        _type = type;
        return this;
    }

    public IDataPartDescriptorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IDataPartDescriptorBuilder WithCategory(string category)
    {
        _category = category;
        return this;
    }

    public IDataPartDescriptorBuilder WithDefaultAgentContextAction(DataPartAgentContextAction defaultAgentContextAction)
    {
        _defaultAgentContextAction = defaultAgentContextAction;
        return this;
    }

    public IDataPartDescriptorBuilder WithRecommendedTransformation(DataPartTransformationMode recommendedTransformation)
    {
        _recommendedTransformation = recommendedTransformation;
        return this;
    }

    public IDataPartDescriptorBuilder WithTraits(DataPartTraits traits)
    {
        _traits = traits;
        return this;
    }

    public IDataPartDescriptorBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public IDataPartDescriptor Build()
    {
        return _type is null
            ? throw new InvalidOperationException("DataPartType is required.")
            : _name is null
            ? throw new InvalidOperationException("Name is required.")
            : _category is null
            ? throw new InvalidOperationException("Category is required.")
            : _defaultAgentContextAction is null
            ? throw new InvalidOperationException("DefaultAgentContextAction is required.")
            : _recommendedTransformation is null
            ? throw new InvalidOperationException("RecommendedTransformation is required.")
            : _traits is null
            ? throw new InvalidOperationException("Traits is required.")
            : new DataPartDescriptor(
                _type.Value,
                _name,
                _category,
                _defaultAgentContextAction.Value,
                _recommendedTransformation.Value,
                _traits.Value,
                _description);
    }
}
