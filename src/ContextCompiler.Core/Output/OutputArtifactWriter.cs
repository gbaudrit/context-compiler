using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Ports;

namespace ContextCompiler.Core.Output
{
    internal sealed class OutputArtifactWriter(IOutputContext outputContext, IFileSystem fs) : IOutputArtifactWriter
    {
        public Task Write(string name, string content)
        {
            var p = Path.Combine(outputContext.OutputPath, name);
            fs.WriteAllText(p, content);
            return Task.CompletedTask;
        }
    }
}
