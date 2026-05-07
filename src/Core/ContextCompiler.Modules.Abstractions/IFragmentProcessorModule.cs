using ContextCompiler.Abstractions.Pipelines.InputIngestion;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Modules.Abstractions;

public interface IFragmentProcessorModule : IModule
{

    Task Process(IFragment fragment, IDataPart dataPart, CancellationToken ct);

}
