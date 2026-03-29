using ContextCompiler.Abstractions.Workspace;
using ContextCompiler.Modules.Abstractions.Views;

namespace ContextCompiler.Modules.Views.View.Index.Json
{
    internal sealed class JsonIndexViewDescriber(IJsonIndexSerializer serializer) : IViewDescriberModule
    {

        public bool CanProcess(IWorkspaceView view, IWorkspaceViewContent? content)
        {
            return view.FilePath.EndsWith(".index.json", StringComparison.InvariantCultureIgnoreCase);
        }

        public Task<IViewDescription> Describe(IWorkspaceView view, IWorkspaceViewContent? content)
        {
            JsonIndex model = serializer.Deserialize(view.Content);
            return Task.FromResult<IViewDescription>(new ViewDescription()
            {
                Title = model.Title,
                FragmentsCount = model.Fragments.Count
            });
        }
    }

    internal sealed class ViewDescription : IViewDescription
    {
        public string Title { get; init; } = string.Empty;
        public int FragmentsCount { get; init; }
    }
}
