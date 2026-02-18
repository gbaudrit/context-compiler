namespace ContextCompiler.Plugins.Abstractions
{
    public interface IGlobalPipelinePlugin : IPlugin
    {
        Task Run(CancellationToken cancellationToken);
    }
}
