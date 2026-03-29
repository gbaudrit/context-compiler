using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output
{
    internal sealed class Output(IOutputContext outputContext) : IOutput
    {

        public string Path => outputContext.OutputPath;

    }
}
