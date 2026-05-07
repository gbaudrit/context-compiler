using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReadResultBuilder
    {
        IFileReadResult Build();
        IFileReadResultBuilder InitNew();
        IFileReadResultBuilder WithContent(IFileInfos content);
    }
}
