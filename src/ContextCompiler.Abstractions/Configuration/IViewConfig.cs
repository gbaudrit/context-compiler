namespace ContextCompiler.Abstractions.Configuration;

public interface IViewConfig
{
    string[] Exclude { get; set; }
    string Id { get; set; }
    bool IncludeFragmentContent { get; set; }
    int? MaxContentChars { get; set; }
    string[] Order { get; set; }
    string[] Renderer { get; set; }
    string[] SelectTags { get; set; }
    string Title { get; set; }
}
