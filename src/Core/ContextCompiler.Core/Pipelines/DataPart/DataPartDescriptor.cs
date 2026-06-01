using ContextCompiler.Abstractions.Pipelines.DataPart;

namespace ContextCompiler.Core.Pipelines.DataPart;

/// <summary>
/// Immutable descriptor for a <see cref="DataPartType"/>.
/// </summary>
public sealed class DataPartDescriptor : IDataPartDescriptor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataPartDescriptor"/> class.
    /// </summary>
    /// <param name="type">The classified data part type.</param>
    /// <param name="name">A stable display name.</param>
    /// <param name="category">The logical category name.</param>
    /// <param name="defaultAgentContextAction">The default AI-agent context decision.</param>
    /// <param name="recommendedTransformation">The default technical transformation.</param>
    /// <param name="traits">Cross-cutting traits associated with the type.</param>
    /// <param name="description">Optional human-readable description.</param>
    public DataPartDescriptor(
        DataPartType type,
        string name,
        string category,
        DataPartAgentContextAction defaultAgentContextAction,
        DataPartTransformationMode recommendedTransformation,
        DataPartTraits traits,
        string? description = null)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(category);

        Type = type;
        Name = name;
        Category = category;
        DefaultAgentContextAction = defaultAgentContextAction;
        RecommendedTransformation = recommendedTransformation;
        Traits = traits;
        Description = description;
    }

    /// <summary>
    /// Gets the classified type.
    /// </summary>
    public DataPartType Type { get; }

    /// <summary>
    /// Gets the stable display name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the logical category.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets the default AI-agent context decision.
    /// </summary>
    public DataPartAgentContextAction DefaultAgentContextAction { get; }

    /// <summary>
    /// Gets the recommended technical transformation.
    /// </summary>
    public DataPartTransformationMode RecommendedTransformation { get; }

    /// <summary>
    /// Gets the trait flags.
    /// </summary>
    public DataPartTraits Traits { get; }

    /// <summary>
    /// Gets an optional human-readable description.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets a value indicating whether the type is personal data.
    /// </summary>
    public bool IsPersonalData => HasTrait(DataPartTraits.PersonalData);

    /// <summary>
    /// Gets a value indicating whether the type is sensitive.
    /// </summary>
    public bool IsSensitive => HasTrait(DataPartTraits.Sensitive);

    /// <summary>
    /// Gets a value indicating whether the type is a secret.
    /// </summary>
    public bool IsSecret => HasTrait(DataPartTraits.Secret);

    /// <summary>
    /// Gets a value indicating whether the type is financial data.
    /// </summary>
    public bool IsFinancial => HasTrait(DataPartTraits.Financial);

    /// <summary>
    /// Gets a value indicating whether the type is an official identifier.
    /// </summary>
    public bool IsOfficialIdentifier => HasTrait(DataPartTraits.OfficialIdentifier);

    /// <summary>
    /// Gets a value indicating whether the type is business-sensitive data.
    /// </summary>
    public bool IsBusinessSensitive => HasTrait(DataPartTraits.BusinessSensitive);

    /// <summary>
    /// Gets a value indicating whether the type is AI-sensitive data.
    /// </summary>
    public bool IsAiSensitive => HasTrait(DataPartTraits.AiSensitive);

    /// <summary>
    /// Gets a value indicating whether the type is structured.
    /// </summary>
    public bool IsStructured => HasTrait(DataPartTraits.Structured);

    /// <summary>
    /// Gets a value indicating whether the type can generally be transformed in a pipeline.
    /// </summary>
    public bool CanBeTransformed => HasTrait(DataPartTraits.Transformable) || RecommendedTransformation != DataPartTransformationMode.None;

    /// <summary>
    /// Gets a value indicating whether reversible controls are preferred.
    /// </summary>
    public bool PrefersReversibleTransformation => HasTrait(DataPartTraits.ReversibleTransformationPreferred);

    /// <summary>
    /// Gets a value indicating whether the data should be encrypted at rest.
    /// </summary>
    public bool ShouldBeEncryptedAtRest => HasTrait(DataPartTraits.RequiresEncryptionAtRest);

    /// <summary>
    /// Gets a value indicating whether the data should normally stay out of LLM input.
    /// </summary>
    public bool ShouldBeExcludedFromLlmInput =>
        HasTrait(DataPartTraits.ExcludeFromLlmInput) ||
        DefaultAgentContextAction == DataPartAgentContextAction.Excluded ||
        DefaultAgentContextAction == DataPartAgentContextAction.RequireExplicitApproval;

    /// <summary>
    /// Gets a value indicating whether the data can normally be included in agent context.
    /// </summary>
    public bool CanBeIncludedInAgentContext =>
        DefaultAgentContextAction is DataPartAgentContextAction.Include or
        DataPartAgentContextAction.Summarize;

    /// <summary>
    /// Returns a string representation of the descriptor.
    /// </summary>
    /// <returns>The descriptor name.</returns>
    public override string ToString()
    {
        return Name;
    }

    /// <summary>
    /// Determines whether the descriptor has the specified trait.
    /// </summary>
    /// <param name="trait">The trait to test.</param>
    /// <returns><see langword="true"/> when the trait is present; otherwise <see langword="false"/>.</returns>
    public bool HasTrait(DataPartTraits trait)
    {
        return (Traits & trait) == trait;
    }
}
