namespace ContextCompiler.Abstractions.Pipelines.DataPart;

public interface IDataPartDescriptorBuilder
{
    IDataPartDescriptorBuilder InitNew();
    IDataPartDescriptorBuilder WithType(DataPartType type);
    IDataPartDescriptorBuilder WithName(string name);
    IDataPartDescriptorBuilder WithCategory(string category);
    IDataPartDescriptorBuilder WithDefaultAgentContextAction(DataPartAgentContextAction defaultAgentContextAction);
    IDataPartDescriptorBuilder WithRecommendedTransformation(DataPartTransformationMode recommendedTransformation);
    IDataPartDescriptorBuilder WithTraits(DataPartTraits traits);
    IDataPartDescriptorBuilder WithDescription(string? description);

    IDataPartDescriptor Build();
}
