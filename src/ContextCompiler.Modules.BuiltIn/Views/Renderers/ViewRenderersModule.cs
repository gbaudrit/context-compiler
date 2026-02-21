using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

namespace ContextCompiler.Modules.BuiltIn.Views.Renderers
{
    internal sealed class ViewRenderersModule(IModulesRegistry modulesRegistry, IViewResultBuilder viewResultBuilder) : IViewRenderersModule
    {
        public async ValueTask<IReadOnlyList<IViewResult>> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            List<Task<IViewResult>> tasks = [];
            foreach (IViewRendererModule renderer in modulesRegistry.ViewRenderers)
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
