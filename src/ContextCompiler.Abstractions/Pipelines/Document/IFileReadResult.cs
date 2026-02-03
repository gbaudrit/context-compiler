using ContextCompiler.Abstractions.Files;

namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public interface IFileReadResult
    {
        IFileInfos Content { get; }
    }
}
