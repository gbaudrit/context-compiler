namespace ContextCompiler.Abstractions.Prompt
{
    public interface IMustNotConstraintBuilder
    {
        IMustNotConstraint Build();
        IMustNotConstraintBuilder InitNew();
        IMustNotConstraintBuilder WithText(string text);
        IMustNotConstraintBuilder WithId(string id);
    }
}
