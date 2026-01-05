using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins
{
    public interface IPlugins
    {
        Task Run(CancellationToken cancellationToken);
    }


    public interface IPlugins<TPlugins> : IPlugins where TPlugins : IPlugin
    {

     
    }
}
