using ContextCompiler.Core.Engine;

namespace ContextCompiler.Sdk;

public sealed class ContextCompilerClient(ICompilerEngine engine)
{
    public Task<int> CompileAsync(string inputPath, string outputPath, CancellationToken ct)
        => engine.CompileAsync(new CompileRequest(inputPath, outputPath), ct);
}
