namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IEvidenceBuilder
    {
        IEvidence Build();
        IEvidenceBuilder InitNew();
        IEvidenceBuilder ForFile(string filePath);
        IEvidenceBuilder WithLocator(string locator);
        IEvidenceBuilder ForContent(string content);
    }
}
