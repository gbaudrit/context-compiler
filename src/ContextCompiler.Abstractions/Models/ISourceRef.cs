using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Models
{
    public interface ISourceRef
    {
        string Path { get; }
        string? Locator { get; }
    }
}
