namespace ContextCompiler.Abstractions.Plugins
{
    public interface IGlobalPipelinePlugin : IPlugin
    {
        Task Run(CancellationToken cancellationToken);
    }
}
