using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Output;

namespace ContextCompiler.Core.Output;

internal sealed class OutputArtifactReader(ICompiledWorkingFolder compiledWorkingFolder) : IOutputArtifactReader
{
    public Task<string> ReadAllText(string filename, CancellationToken cancellationToken)
    {
        string path = Path.Combine(compiledWorkingFolder.Path(), filename);
        return Task.FromResult(File.ReadAllText(path));
    }
}
