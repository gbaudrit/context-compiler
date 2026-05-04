using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(ContextCompiler.Prompting.Modules.Composers.Objectives.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Composers.Glossary.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Composers.General.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Composers.Constraints.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Composers.Assumptions.DependencyInjection).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Composers.Audiences.DependencyInjection).Assembly,
                ];
        }
    }
}
