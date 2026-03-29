namespace ContextCompiler.Modules.Abstractions
{
    public interface IGlobalPipelineModule : IModule
    {
        Task Run(CancellationToken cancellationToken);
    }
}
