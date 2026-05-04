namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IMustConstraintBuilder
    {
        IMustConstraint Build();
        IMustConstraintBuilder InitNew();
        IMustConstraintBuilder WithId(string id);
        IMustConstraintBuilder WithRationale(string rationale);
        IMustConstraintBuilder WithText(string text);
    }
}
