using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    public sealed record FileReadResult(IFileInfos Content) : IFileReadResult;

}
