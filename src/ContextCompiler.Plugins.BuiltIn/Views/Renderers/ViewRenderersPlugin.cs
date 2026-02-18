using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Plugins.Abstractions;
using ContextCompiler.Plugins.Abstractions.Views.Renderers;

namespace ContextCompiler.Plugins.BuiltIn.Views.Renderers
{
    internal sealed class ViewRenderersPlugin(IPluginRegistry pluginRegistry, IViewResultBuilder viewResultBuilder) : IViewRenderersPlugin
    {
        public async ValueTask<IReadOnlyList<IViewResult>> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            List<Task<IViewResult>> tasks = [];
            foreach (IViewRendererPlugin renderer in pluginRegistry.ViewRenderers)
            {
                if (renderer.CanRender(def))
                {
                    async Task<IViewResult> call()
                    {
                        string content = await renderer.RenderAsync(def, fragments, ct);

                        return viewResultBuilder.InitNew()
                                               .WithId(def.Id)
                                               .WithTitle(def.Title)
                                               .WithContent(content)
                                               .WithFilename($"view.{def.Id}{renderer.OutputFileExtension}")
                                               .WithMime(renderer.OutputMimeType)
                                               .Build();
                    }

                    tasks.Add(call());
                }
            }

            return await Task.WhenAll(tasks);
            // Implement rendering logic here
        }
    }
}
