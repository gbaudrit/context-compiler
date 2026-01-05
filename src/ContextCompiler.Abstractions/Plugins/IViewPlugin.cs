using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Plugins;

public interface IViewPlugin : IPlugin
{
    string ViewId { get; }
    ValueTask<IReadOnlyList<ViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct);
}

public sealed record ViewContext(
    ViewsConfig Config,
    string RootPath,
    IReasoningIr ReasoningIr,
    IReadOnlyDictionary<string, object>? Inputs = null,
    bool EmitJson = true,
    bool EmitMarkdown = true
);

public sealed record ViewResult(
    string ViewId,
    string Title,
    string Rendered,
    string RelativePath,
    string Content,
    string Mime,
    IReadOnlyDictionary<string, string>? Metadata = null
);

