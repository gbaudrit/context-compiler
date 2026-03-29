using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Prompt.Standard
{
    public class Pack : IPack
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Prompt.Composers.Views.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.Objectives.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.Glossary.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.General.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.Constraints.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.Assumptions.DependencyInjection).Assembly,
                typeof(Modules.Prompt.Composers.Audiences.DependencyInjection).Assembly,
                ];
        }
    }
}
