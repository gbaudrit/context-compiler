using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Pipelines.InputIngestion;

namespace ContextCompiler.Modules.Abstractions;

public interface IFragmentProcessorModule : IModule
{

    Task Process(IFragment fragment, IDataPart dataPart, CancellationToken ct);

}
