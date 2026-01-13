using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Abstractions.Files
{
    public interface IFileReader
    {
        ValueTask<Stream> ReadAsync(string path, CancellationToken ct);
    }
}
