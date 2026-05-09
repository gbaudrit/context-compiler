using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Modules.Abstractions.Views.Renderers
{
    public interface IViewRendererModule
    {
        string OutputFileExtension { get; }
        string OutputMimeType { get; }

        bool CanRender(IViewConfigSection def);
        Task<string> RenderAsync(IViewConfigSection def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
