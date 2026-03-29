using System.Text.Json;

namespace ContextCompiler.Abstractions.Configuration.Sections
{
    public interface IRootConfigSection
    {
        string Schema { get; }
        IContextConfigSection Context { get; }
        IEnumerable<IFileConfigSection> Files { get; }
        IPersonasConfigSection? Personas { get; }
        IViewsConfigSection Views { get; }
        List<string> Renderers { get; set; }

        void AddFile(string[] Includes, string[] Excludes, ISubFilesMatchConfigSection[] Subs, string[] Tags, JsonElement? Options);
        void AddView(string Id, string? title, string[] selectTags, string[] Excludes, string[] order, string[] renderers);
    }
}
