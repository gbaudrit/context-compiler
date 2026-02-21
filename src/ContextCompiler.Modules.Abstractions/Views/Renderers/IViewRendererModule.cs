using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Modules.Abstractions.Views.Renderers
{
    public interface IViewRendererModule
    {
        string OutputFileExtension { get; }
        string OutputMimeType { get; }

        bool CanRender(IViewConfig def);
        Task<string> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
