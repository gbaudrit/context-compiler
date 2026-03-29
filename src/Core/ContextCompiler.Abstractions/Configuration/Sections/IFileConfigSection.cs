using System.Text.Json;

namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface IFileConfigSection
{
    string[] Includes { get; set; }
    string[] Excludes { get; set; }
    ISubFilesMatchConfigSection[] Subs { get; set; }
    string[] Tags { get; set; }
    JsonElement? Options { get; set; }
}
