using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Packs.Readers.Standard
{
    public class Pack : IPack
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(Modules.Readers.Excel.DependencyInjection).Assembly,
                typeof(Modules.Readers.Markdown.DependencyInjection).Assembly,
                typeof(Modules.Readers.Pdf.DependencyInjection).Assembly,
                typeof(Modules.Readers.Text.DependencyInjection).Assembly,
                typeof(Modules.Readers.Yaml.DependencyInjection).Assembly
                ];
        }
    }
}
