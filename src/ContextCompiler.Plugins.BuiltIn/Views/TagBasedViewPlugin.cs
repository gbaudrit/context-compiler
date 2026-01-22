using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.Views;

public sealed class TagBasedViewPlugin(IViewResultBuilder viewResultBuilder, IViewRenderersPlugin viewRenderersPlugin) : IViewPlugin
{

    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.views.tag_based", GlobalPipelinePluginKinds.View, priority: 100);

    public string ViewId => "views.tagbased";

    public async ValueTask<IReadOnlyList<IViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var views = (ctx.Config.Views ?? Array.Empty<ViewConfig>())
            .OrderBy(v => v.Id, StringComparer.Ordinal) // deterministic view output order
            .ToArray();

        var artifacts = new List<IViewResult>(capacity: views.Length * 2);

        foreach (var def in views)
        {
            ct.ThrowIfCancellationRequested();

            var fragments = ViewSelector.SelectFragments(ctx.ReasoningIr, def);

            var renderResult = await viewRenderersPlugin.RenderAsync(def, fragments, ct);
            artifacts.AddRange(renderResult);
        }

        // async-friendly signature, no actual awaits needed
        return await ValueTask.FromResult<IReadOnlyList<IViewResult>>(artifacts);
    }
}

internal static class WildcardTagMatcher
{
    public static bool MatchesAny(IReadOnlyList<ITag> tags, IEnumerable<string> patterns)
        => patterns.Any(p => Matches(tags, p));

    public static bool Matches(IReadOnlyList<ITag> tags, string pattern)
    {
        // pattern: "ns:value" where value may contain "*"
        var idx = pattern.IndexOf(':');
        if (idx <= 0 || idx == pattern.Length - 1)
            return false;

        var ns = pattern[..idx];
        var pv = pattern[(idx + 1)..];

        IEnumerable<string> values = tags.Where(t => t.Name == ns).Select(t => t.Value ?? "");
        if (!values.Any())
            return false;

        return WildcardEquals(values, pv);
    }

    private static bool WildcardEquals(IEnumerable<string> values, string pattern)
    {
        // Only supports '*' wildcard (deterministic, simple)
        if (pattern == "*") return true;

        var star = pattern.IndexOf('*');
        if (star < 0) return values.Any(x => string.Equals(x, pattern, StringComparison.OrdinalIgnoreCase));

        var prefix = pattern[..star];
        var suffix = pattern[(star + 1)..];

        if (!values.Any(v => v.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))) return false;
        if (!values.Any(v => v.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))) return false;

        return values.Any(x => x.Length >= prefix.Length + suffix.Length);
    }
}

internal static class Deterministic
{
    public static int GetSeverity(IReadOnlyDictionary<string, string> tags)
    {
        // accepted tag keys: "riskSeverity" or "severity"
        if (tags.TryGetValue("riskSeverity", out var s) || tags.TryGetValue("severity", out s))
        {
            // normalize: critical=3 warning=2 info=1 else parse int
            if (string.Equals(s, "critical", StringComparison.OrdinalIgnoreCase)) return 3;
            if (string.Equals(s, "warning", StringComparison.OrdinalIgnoreCase)) return 2;
            if (string.Equals(s, "info", StringComparison.OrdinalIgnoreCase)) return 1;
            if (int.TryParse(s, out var n)) return n;
        }
        return 0;
    }

    public static string NormalizeNewlines(string s) => s.Replace("\r\n", "\n").Replace("\r", "\n");
}

internal static class ViewSelector
{
    public static IReadOnlyList<IFragment> SelectFragments(IReasoningIr ir, ViewConfig def)
    {
        var include = def.Select ?? Array.Empty<string>();
        var exclude = def.Exclude ?? Array.Empty<string>();

        var selected = ir.Fragments
            .Where(f =>
            {
                var tags = f.Tags;
                var incOk = include.Length == 0 || WildcardTagMatcher.MatchesAny(tags, include);
                var excHit = exclude.Length != 0 && WildcardTagMatcher.MatchesAny(tags, exclude);
                return incOk && !excHit;
            });

        // deterministic ordering
        return Order(selected, def.Order).ToArray();
    }

    private static IEnumerable<IFragment> Order(IEnumerable<IFragment> frags, string[] order)
    {
        //IOrderedEnumerable<IFragment>? o = null;

        //if (order.RiskSeverityDesc)
        //    o = frags.OrderByDescending(f => Deterministic.GetSeverity(f.Tags));

        //// stable ties
        //if (o is null) o = frags.OrderBy(f => f.Source.Path, StringComparer.Ordinal);
        //else if (order.ThenBySourcePath) o = o.ThenBy(f => f.Source.Path, StringComparer.Ordinal);

        //if (order.ThenByLocator) o = o.ThenBy(f => f.Source.Locator, StringComparer.Ordinal);
        //if (order.ThenByEvidenceKey) o = o.ThenBy(f => f.Key.Value, StringComparer.Ordinal);

        return frags;
    }
}

internal static class ViewRenderer
{
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        WriteIndented = true
    };

    public static (string md, string json) Render(ViewConfig def, IReadOnlyList<IFragment> fragments)
    {
        var md = RenderMarkdown(def, fragments);
        var json = RenderJson(def, fragments);
        return (md, json);
    }

    private static string RenderMarkdown(ViewConfig def, IReadOnlyList<IFragment> fragments)
    {
        var sb = new StringBuilder();
        sb.AppendLine(CultureInfo.InvariantCulture,$"# View: {def.Id}");
        sb.AppendLine();
        sb.AppendLine(def.Title);
        sb.AppendLine();
        sb.AppendLine("## Evidence");
        sb.AppendLine();

        foreach (var f in fragments)
        {
            sb.AppendLine(CultureInfo.InvariantCulture, $"- **EK:** `{f.Evidence.EvidenceKey}`  ");
            sb.AppendLine(CultureInfo.InvariantCulture, $"  **ER:** `{f.Evidence.EvidenceRevision}`  ");
            sb.AppendLine(CultureInfo.InvariantCulture, $"  **Source:** `{f.Source.Path}#{f.Source.Locator}`  ");

            if (def.IncludeFragmentContent)
            {
                var content = Deterministic.NormalizeNewlines(f.Content);
                if (def.MaxContentChars is int max && content.Length > max)
                    content = content[..max] + "…";

                sb.AppendLine();
                sb.AppendLine("```");
                sb.AppendLine(content);
                sb.AppendLine("```");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static string RenderJson(ViewConfig def, IReadOnlyList<IFragment> fragments)
    {
        var model = new
        {
            contractVersion = "1.0",
            viewId = def.Id,
            title = def.Title,
            fragments = fragments.Select(f => new
            {
                ek = f.Evidence.EvidenceKey,
                er = f.Evidence.EvidenceRevision,
                source = new { path = f.Source.Path, locator = f.Source.Locator },
                tags = f.Tags
            }).ToArray()
        };

        return JsonSerializer.Serialize(model, JsonOpts);
    }
}
