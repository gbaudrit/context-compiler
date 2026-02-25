using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Views
{
    public interface IViewsProvider
    {

        IReadOnlyList<IViewConfigSection> Views { get; }

    }
}
