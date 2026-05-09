using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Composers.Objectives.DependencyInjection).Assembly,
                typeof(Modules.Composers.Glossary.DependencyInjection).Assembly,
                typeof(Modules.Composers.General.DependencyInjection).Assembly,
                typeof(Modules.Composers.Constraints.DependencyInjection).Assembly,
                typeof(Modules.Composers.Assumptions.DependencyInjection).Assembly,
                typeof(Modules.Composers.Audiences.DependencyInjection).Assembly,
                ];
        }
    }
}
