using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Modules.Abstractions;

public interface IViewModule : IModule
{
    string ViewId { get; }
    ValueTask<IReadOnlyList<IViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct);
}

public sealed record ViewContext(
    IViewsConfig Config,
    IReasoningIr ReasoningIr,
    IReadOnlyDictionary<string, object>? Inputs = null,
    bool EmitJson = true,
    bool EmitMarkdown = true
);



