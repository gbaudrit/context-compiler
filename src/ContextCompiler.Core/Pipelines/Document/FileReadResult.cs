using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Pipelines.Document;

namespace ContextCompiler.Core.Pipelines.Document
{
    public sealed record FileReadResult(string Mime, byte[] Bytes) : IFileReadResult;

}
