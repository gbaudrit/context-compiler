using ContextCompiler.Core.Engine;

namespace ContextCompiler.Sdk;

public sealed class ContextCompilerClient(ICompilerEngine engine)
{
    public Task<int> CompileAsync(string inputPath, string outputPath, bool cleanOutput, string name, CancellationToken ct)
        => engine.CompileAsync(new CompileRequest(inputPath, outputPath, name, cleanOutput), ct);
}
