//using ContextCompiler.Abstractions.Plugins;

//using Microsoft.Extensions.DependencyInjection;

//namespace ContextCompiler.Infrastructure.PluginLoading
//{
//    internal sealed class GlobalPipelinePlugins<TPlugin>(IServiceProvider services) : IPlugins<TPlugin> where TPlugin : IGlobalPipelinePlugin
//    {
//        public Task Run(CancellationToken cancellationToken)
//        {
//            var plugins = services.GetServices<TPlugin>().ToList();
//            return Task.WhenAll(plugins.Select(p => p.Run(cancellationToken)));
//        }
//    }
//}
