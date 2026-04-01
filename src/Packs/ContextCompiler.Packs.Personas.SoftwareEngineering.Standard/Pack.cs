using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Personas.SoftwareEngineering.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Personas.Analysts.Business.DependencyInjection).Assembly,
                typeof(Modules.Personas.Testers.Analyst.DependencyInjection).Assembly,
                ];
        }
    }
}
