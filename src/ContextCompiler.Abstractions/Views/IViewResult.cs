using System;
using System.Collections.Generic;
using System.Text;

namespace ContextCompiler.Abstractions.Views
{
    public interface IViewResult
    {
        public string ViewId { get; }
        string Title { get; }
        string Filename { get; }
        string Content { get; }
        string Mime { get; }
        IReadOnlyDictionary<string, string>? Metadata { get; }
    }
}
