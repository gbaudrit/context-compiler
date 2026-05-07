using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Core.Files
{
    internal sealed class FileReadResult : IFileReadResult
    {
        public required IFileInfos Content { get; init; }

    }
}
