using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Modules.Abstractions.Views.Renderers
{
    public interface IViewRenderersModule
    {
        ValueTask<IReadOnlyList<IViewResult>> RenderAsync(IViewConfigSection def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
