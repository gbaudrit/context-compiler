using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Views;

public sealed class DefaultViewModule(IViewResultBuilder viewResultBuilder) : IViewModule
{
    public ViewModuleMetadata Metadata => IViewModule.Meta("views.default", ViewModuleKinds.Renderer, priority: 0);
    public string ViewId => "default";

    public Task<IReadOnlyList<IViewResult>> Run(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        ICompiledContext ir = ctx.CompiledContext;

        StringBuilder sb = new();
        _ = sb.AppendLine("## Evidence");
        _ = sb.AppendLine();
        foreach (IFragment f in ir.Fragments)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"### {f.Evidence.EvidenceKey}");
            _ = sb.AppendLine();
            _ = sb.AppendLine(f.Content);
            _ = sb.AppendLine();
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"_Source: `{f.Source.Uri.AbsolutePath}` {(!string.IsNullOrEmpty(f.Source.Locator) ? $"({f.Source.Locator})" : "")}_");
            _ = sb.AppendLine();
        }

        return Task.FromResult<IReadOnlyList<IViewResult>>([ viewResultBuilder.InitNew()
                                                                              .WithId(ViewId)
                                                                              .WithTitle("Default View")
                                                                              .WithContent(sb.ToString())
                                                                              .WithMime("text/markdown")
                                                                              .WithFilename("view.default.md")
                                                                              .WithRendererType(GetType())
                                                                              .Build() ]);
    }
}
