using System.Text.Json;

namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface ISourceConfigSection
{
    Uri Url { get; set; }
    string[] Includes { get; set; }
    string[] Excludes { get; set; }
    ISubFilesMatchConfigSection[] Subs { get; set; }
    string[] Tags { get; set; }
    JsonElement? Options { get; set; }
    string OptionsKey { get; }
}
