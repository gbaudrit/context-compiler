namespace ContextCompiler.Prompting.Abstractions.Prompt
{
    public interface IMustNotConstraintBuilder
    {
        IMustNotConstraint Build();
        IMustNotConstraintBuilder InitNew();
        IMustNotConstraintBuilder WithId(string id);
        IMustNotConstraintBuilder WithRationale(string rationale);
        IMustNotConstraintBuilder WithText(string text);
    }
}
