using System.Text.Json;

namespace ContextCompiler.Abstractions.Configuration
{
    public interface ICtxcConfig
    {
        string Schema { get; }
        IContextConfig Context { get; set; }
        List<IFileConfig> Files { get; set; }
        IPersonasConfig? Personas { get; set; }
        IViewsConfig Views { get; set; }
        List<string> Renderers { get; set; }

        void AddFile(string[] Includes, string[] Excludes, ISubFilesMatchConfig[] Subs, string[] Tags, JsonElement? Options);
    }
}
