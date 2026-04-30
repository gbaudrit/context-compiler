using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Views.Standard
{
    public class ViewsStandardPack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Views.DependencyInjection).Assembly,
                typeof(Modules.Views.View.Index.Json.DependencyInjection).Assembly
                ];
        }
    }
}
