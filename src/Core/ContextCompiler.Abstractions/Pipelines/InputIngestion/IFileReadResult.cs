using ContextCompiler.Abstractions.Files;

namespace ContextCompiler.Abstractions.Pipelines.InputIngestion
{
    public interface IFileReadResult
    {
        IFileInfos Content { get; }
    }
}
