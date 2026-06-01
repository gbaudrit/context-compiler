using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Pipelines.InputIngestion
{
    public sealed record FileReadResult(IFileInfos Content) : IFileReadResult;

}
