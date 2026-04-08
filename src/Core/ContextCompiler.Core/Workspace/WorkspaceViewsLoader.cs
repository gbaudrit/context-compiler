using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Workspace;

namespace ContextCompiler.Core.Workspace
{
    internal sealed class WorkspaceViewLoader(ICompiledWorkingFolder compiledWorkingFolder) : IWorkspaceViewsLoader
    {

        public Task<IReadOnlyList<IWorkspaceView>> Load()
        {
            List<IWorkspaceView> views = [];
            string path = compiledWorkingFolder.Path;


            foreach (string file in Directory.EnumerateFiles(path, "view.*.json", SearchOption.AllDirectories))
            {
                string viewNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

                List<IWorkspaceViewContent> contents = [];
                foreach (string contentfile in Directory.EnumerateFiles(path, $"{viewNameWithoutExtension}.*", SearchOption.AllDirectories))
                {
                    contents.Add(new WorkspaceViewContent() { Content = File.ReadAllText(contentfile), FilePath = contentfile, LastModified = File.GetLastWriteTime(contentfile) });
                }

                views.Add(new WorkspaceView()
                {
                    Name = Path.GetFileNameWithoutExtension(file).Replace("view.", ""),
                    Description = $"View loaded from {file}",
                    FilePath = file,
                    Content = File.ReadAllText(file),
                    LastModified = File.GetLastWriteTime(file),
                    Contents = contents.AsReadOnly()
                });
            }

            return Task.FromResult<IReadOnlyList<IWorkspaceView>>(views.AsReadOnly());
        }

    }
}
