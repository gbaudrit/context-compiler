using System.Text;
using ContextCompiler.Abstractions.Plugins;

namespace ContextCompiler.Plugins.BuiltIn.Views;

public sealed class DefaultViewPlugin : IViewPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.view.default", PluginKinds.View, priority: 0);
    public string ViewId => "default";

    public Task<ViewResult> BuildAsync(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var ir = ctx.ReasoningIr;

        var sb = new StringBuilder();
        sb.AppendLine("## Evidence");
        sb.AppendLine();
        foreach (var f in ir.Fragments)
        {
            sb.AppendLine($"### {f.Key.Value}");
            sb.AppendLine();
            sb.AppendLine(f.Content);
            sb.AppendLine();
            sb.AppendLine($"_Source: `{f.Source.Path}` {(!string.IsNullOrEmpty(f.Source.Locator) ? $"({f.Source.Locator})" : "")}_");
            sb.AppendLine();
        }

        return Task.FromResult(new ViewResult(ViewId, "Default View", sb.ToString()));
    }
}
