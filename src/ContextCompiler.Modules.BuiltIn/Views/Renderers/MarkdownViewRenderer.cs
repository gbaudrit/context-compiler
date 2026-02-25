using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

namespace ContextCompiler.Modules.BuiltIn.Views.Renderers
{
    internal sealed class MarkdownViewRenderer : IViewRendererModule
    {

        public bool CanRender(IViewConfigSection def)
        {
            return def.Renderer.Contains("md");
        }

        public string OutputFileExtension => ".md";

        public string OutputMimeType => "text/markdown";

        public Task<string> RenderAsync(IViewConfigSection def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
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

            return Task.FromResult(sb.ToString());
        }

    }
}
