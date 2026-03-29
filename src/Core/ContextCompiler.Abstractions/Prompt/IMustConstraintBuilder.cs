namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustConstraintBuilder
    {
        IMustConstraint Build();
        IMustConstraintBuilder InitNew();
        IMustConstraintBuilder WithText(string text);
        IMustConstraintBuilder WithId(string id);
    }
}
