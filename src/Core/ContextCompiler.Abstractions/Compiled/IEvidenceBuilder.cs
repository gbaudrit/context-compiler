namespace ContextCompiler.Abstractions.Compiled
{
    public interface IEvidenceBuilder
    {
        IEvidence Build();
        IEvidenceBuilder InitNew();
        IEvidenceBuilder ForUri(Uri uri);
        IEvidenceBuilder WithLocator(string locator);
        IEvidenceBuilder ForContent(string content);
    }
}
