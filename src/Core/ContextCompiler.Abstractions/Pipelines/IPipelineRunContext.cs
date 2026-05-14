namespace ContextCompiler.Abstractions.Pipelines;

public interface IPipelineRunContext
{
    IPipeline Pipeline { get; }

    string PhaseKey { get; }
}
