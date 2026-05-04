using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Packs.Personas.SoftwareEngineering.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(ContextCompiler.Prompting.Modules.Personas.Analysts.Business.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Personas.Testers.Analyst.DependencyInjection).Assembly,
                ];
        }
    }
}
