using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Readers.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Excel.DependencyInjection).Assembly,
                typeof(Modules.Markdown.DependencyInjection).Assembly,
                typeof(Modules.Pdf.DependencyInjection).Assembly,
                typeof(Modules.Text.DependencyInjection).Assembly,
                typeof(Modules.Yaml.DependencyInjection).Assembly
                ];
        }
    }
}
