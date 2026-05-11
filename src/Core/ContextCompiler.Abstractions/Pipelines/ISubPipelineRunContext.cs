namespace ContextCompiler.Abstractions.Pipelines;

public interface ISubPipelineRunContext : IPipelineRunContext
{
    IPipelineRunContext Parent { get; }
}
