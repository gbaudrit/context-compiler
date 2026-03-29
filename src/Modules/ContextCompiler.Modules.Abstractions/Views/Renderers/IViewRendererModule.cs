using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.ReasoningIR;

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
