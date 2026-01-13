using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Files
{
    internal sealed class FileReadResult : IFileReadResult
    {
        public required IFileInfos Content { get; init; }

    }
}
