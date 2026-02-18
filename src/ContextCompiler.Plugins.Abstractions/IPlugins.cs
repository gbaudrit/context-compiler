namespace ContextCompiler.Plugins.Abstractions
{
    public interface IPlugins
    {
        Task Run(CancellationToken cancellationToken);
    }


    public interface IPlugins<TPlugins> : IPlugins where TPlugins : IPlugin
    {


    }
}
