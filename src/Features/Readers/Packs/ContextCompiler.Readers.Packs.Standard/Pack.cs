using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Readers.Packs.Standard
{
    public class Pack : IPackModule
    {
        public IEnumerable<Assembly> Discover()
        {
            return [
                typeof(ContextCompiler.Readers.Modules.Excel.DependencyInjection).Assembly,
                typeof(ContextCompiler.Readers.Modules.Markdown.DependencyInjection).Assembly,
                typeof(ContextCompiler.Readers.Modules.Pdf.DependencyInjection).Assembly,
                typeof(ContextCompiler.Readers.Modules.Text.DependencyInjection).Assembly,
                typeof(ContextCompiler.Readers.Modules.Yaml.DependencyInjection).Assembly
                ];
        }
    }
}
