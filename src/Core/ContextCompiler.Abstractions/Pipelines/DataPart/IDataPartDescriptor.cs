namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartDescriptor
    {
        bool CanBeIncludedInAgentContext { get; }
        bool CanBeTransformed { get; }
        string Category { get; }
        DataPartAgentContextAction DefaultAgentContextAction { get; }
        string? Description { get; }
        bool IsAiSensitive { get; }
        bool IsBusinessSensitive { get; }
        bool IsFinancial { get; }
        bool IsOfficialIdentifier { get; }
        bool IsPersonalData { get; }
        bool IsSecret { get; }
        bool IsSensitive { get; }
        bool IsStructured { get; }
        string Name { get; }
        bool PrefersReversibleTransformation { get; }
        DataPartTransformationMode RecommendedTransformation { get; }
        bool ShouldBeEncryptedAtRest { get; }
        bool ShouldBeExcludedFromLlmInput { get; }
        DataPartTraits Traits { get; }
        DataPartType Type { get; }

        bool HasTrait(DataPartTraits trait);
        string ToString();
    }
}
