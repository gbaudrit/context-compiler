namespace ContextCompiler.Abstractions.ReasoningIR
{
    public interface IEvidenceBuilder
    {
        IEvidence Build();
        IEvidenceBuilder InitNew();
        IEvidenceBuilder ForFile(string filePath);
        IEvidenceBuilder ForTranscodedFragment(ITranscodedFragment transcodedFragment);
    }
}
