using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

namespace ContextCompiler.Views;

public sealed class TagBasedViewModule(IViewResultBuilder viewResultBuilder, IViewRenderersModule viewRenderersModule) : IViewModule
{

    public ViewModuleMetadata Metadata => IViewModule.Meta("views.tagbased", ViewModuleKinds.Renderer, priority: 100);

    public string ViewId => "views.tagbased";

    public async Task<IReadOnlyList<IViewResult>> Run(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        IViewConfigSection[] views = [.. (ctx.Config.Views ?? []).OrderBy(v => v.Id, StringComparer.Ordinal)];

        List<IViewResult> artifacts = [];

        foreach (IViewConfigSection? def in views)
        {
            ct.ThrowIfCancellationRequested();

            IReadOnlyList<IFragment> fragments = ViewSelector.SelectFragments(ctx.CompiledContext, def);

            IReadOnlyList<IViewResult> renderResult = await viewRenderersModule.RenderAsync(def, fragments, ct);
            artifacts.AddRange(renderResult);
        }

        // async-friendly signature, no actual awaits needed
        return await ValueTask.FromResult<IReadOnlyList<IViewResult>>(artifacts);
    }
}

internal static class WildcardTagMatcher
{
    public static bool MatchesAny(IReadOnlyList<ITag> tags, IEnumerable<string> patterns)
    {
        return patterns.Any(p => Matches(tags, p));
    }

    public static bool Matches(IReadOnlyList<ITag> tags, string pattern)
    {
        // pattern: "ns:value" where value may contain "*"
        int idx = pattern.IndexOf(':');
        if (idx <= 0 || idx == pattern.Length - 1)
        {
            return false;
        }

        string ns = pattern[..idx];
        string pv = pattern[(idx + 1)..];

        IEnumerable<string> values = tags.Where(t => t.Name == ns).Select(t => t.Value ?? "");
        return values.Any() && WildcardEquals(values, pv);
    }

    private static bool WildcardEquals(IEnumerable<string> values, string pattern)
    {
        // Only supports '*' wildcard (deterministic, simple)
        if (pattern == "*")
        {
            return true;
        }

        int star = pattern.IndexOf('*');
        if (star < 0)
        {
            return values.Any(x => string.Equals(x, pattern, StringComparison.OrdinalIgnoreCase));
        }

        string prefix = pattern[..star];
        string suffix = pattern[(star + 1)..];

        return values.Any(v => v.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
               && values.Any(v => v.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
               && values.Any(x => x.Length >= prefix.Length + suffix.Length);
    }
}

internal static class Deterministic
{
    public static int GetSeverity(IReadOnlyDictionary<string, string> tags)
    {
        // accepted tag keys: "riskSeverity" or "severity"
        if (tags.TryGetValue("riskSeverity", out string? s) || tags.TryGetValue("severity", out s))
        {
            // normalize: critical=3 warning=2 info=1 else parse int
            if (string.Equals(s, "critical", StringComparison.OrdinalIgnoreCase))
            {
                return 3;
            }

            if (string.Equals(s, "warning", StringComparison.OrdinalIgnoreCase))
            {
                return 2;
            }

            if (string.Equals(s, "info", StringComparison.OrdinalIgnoreCase))
            {
                return 1;
            }

            if (int.TryParse(s, out int n))
            {
                return n;
            }
        }
        return 0;
    }

    public static string NormalizeNewlines(string s)
    {
        return s.Replace("\r\n", "\n").Replace("\r", "\n");
    }
}

internal static class ViewSelector
{
    public static IReadOnlyList<IFragment> SelectFragments(ICompiledContext ir, IViewConfigSection def)
    {
        string[] include = def.SelectTags ?? [];
        string[] exclude = def.Excludes ?? [];

        IEnumerable<IFragment> selected = ir.Fragments
            .Where(f =>
            {
                IReadOnlyList<ITag> tags = f.Tags;
                bool incOk = include.Length == 0 || WildcardTagMatcher.MatchesAny(tags, include);
                bool excHit = exclude.Length != 0 && WildcardTagMatcher.MatchesAny(tags, exclude);
                return incOk && !excHit;
            });

        // deterministic ordering
        return [.. Order(selected, def.Order)];
    }

#pragma warning disable IDE0060 // Remove unused parameter
    private static IEnumerable<IFragment> Order(IEnumerable<IFragment> frags, string[] order)
#pragma warning restore IDE0060 // Remove unused parameter
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

    public static (string md, string json) Render(IViewConfigSection def, IReadOnlyList<IFragment> fragments)
    {
        string md = RenderMarkdown(def, fragments);
        string json = RenderJson(def, fragments);
        return (md, json);
    }

    private static string RenderMarkdown(IViewConfigSection def, IReadOnlyList<IFragment> fragments)
    {
        StringBuilder sb = new();
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"# View: {def.Id}");
        _ = sb.AppendLine();
        _ = sb.AppendLine(def.Title);
        _ = sb.AppendLine();
        _ = sb.AppendLine("## Evidence");
        _ = sb.AppendLine();

        foreach (IFragment f in fragments)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- **EK:** `{f.Evidence.EvidenceKey}`  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"  **ER:** `{f.Evidence.EvidenceRevision}`  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"  **Source:** `{f.Source.Path}#{f.Source.Locator}`  ");

            if (def.IncludeFragmentContent)
            {
                string content = Deterministic.NormalizeNewlines(f.Content);
                if (def.MaxContentChars is int max && content.Length > max)
                {
                    content = content[..max] + "…";
                }

                _ = sb.AppendLine();
                _ = sb.AppendLine("```");
                _ = sb.AppendLine(content);
                _ = sb.AppendLine("```");
            }

            _ = sb.AppendLine();
        }

        return sb.ToString();
    }

    private static string RenderJson(IViewConfigSection def, IReadOnlyList<IFragment> fragments)
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
