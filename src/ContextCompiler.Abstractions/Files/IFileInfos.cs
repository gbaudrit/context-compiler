using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileInfos
    {
        string Path { get; }
        string MediaType { get; }
        Type ReaderType { get; }
        string? Text { get; }
        IReadOnlyDictionary<string, string>? Metadata { get; }

    }
}
