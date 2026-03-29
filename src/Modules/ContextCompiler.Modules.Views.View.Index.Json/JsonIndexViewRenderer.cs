using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Views.View.Index.Json
{
    internal sealed class JsonIndexViewRenderer(IJsonIndexSerializer jsonIndexSerializer, ILogger<JsonIndexViewRenderer> logger) : IViewRendererModule
    {
        public bool CanRender(IViewConfigSection def)
        {
            return def.Renderers.Contains("index.json");
        }

        public string OutputFileExtension => ".index.json";
        public string OutputMimeType => "application/json";

        public Task<string> RenderAsync(IViewConfigSection def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            logger.LogInformation("Rendering JSON index view for '{ViewId}' with {FragmentCount} fragments", def.Id, fragments.Count);

            JsonIndex model = new()
            {
                ContractVersion = "1.0",
                ViewId = def.Id,
                Title = def.Title,
                Fragments = [.. fragments.Select(f => new JsonFragment()
                {
                    Ek = f.Evidence.EvidenceKey,
                    Er = f.Evidence.EvidenceRevision,
                    Source = new { f.Source.Path, f.Source.Locator },
                    Tags = [.. f.Tags.Select(t => new Tag() { Name = t.Name, Value = t.Value ?? "" })],
                })]
            };

            return Task.FromResult(jsonIndexSerializer.Serialize(model));
        }

    }
}
